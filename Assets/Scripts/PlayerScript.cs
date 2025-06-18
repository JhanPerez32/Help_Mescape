using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    Vector2 playerPosition;
    Rigidbody playerRigidbody;
    
    public float moveSpeed = 15f;
    public float jumpHeight = 10f;

    public bool isGrounded = false;
    public bool ObstacleHit = false;

    public AudioSource PlayerFiringFX;
    public AudioSource PlayerDestroyFX;
    public AudioSource PlayerLandedFX;
    public GameObject HitEffect;

    public Transform BulletSpawn;
    public GameObject BulletPrefab;

    void Start()
    {
        playerPosition = transform.position;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        playerPosition.x += moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        playerPosition.y = transform.position.y;

        transform.position = playerPosition;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

        }

        ShootBullets();

    }

    void ShootBullets()
    {
        float direction = 0;

        if (Input.GetAxis("Horizontal") >= 0)
        {
            BulletSpawn.position = transform.position + new Vector3(0f, 0, 0);
            direction = 1;

        }else if (Input.GetAxis("Horizontal") < 0)
        {
            BulletSpawn.position = transform.position - new Vector3(0f, 0, 0);
            direction = -1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            PlayerFiringFX.Play();
            GameObject g = Instantiate(BulletPrefab, BulletSpawn.position, Quaternion.identity);
            g.GetComponent<BulletScript>().BulletSpeed *= direction;
            Destroy(g, 1); //Destroy in 1 Seconds
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag.Equals("Ground"))
        {
            PlayerLandedFX.Play(); //Landed Sound FX
            isGrounded = true;
        }

        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            ObstacleHit = true;
            Instantiate(HitEffect, transform.position, transform.rotation); //Animation Effect.
            PlayerDestroyFX.Play(); //Explosion Sound FX
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame(); //Restarting level.
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (playerRigidbody.position.y < -150f)
        {
            Instantiate(HitEffect, transform.position, transform.rotation); //Animation Effect.
            PlayerDestroyFX.Play(); //Explosion Sound FX
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame(); //Restarting level.
        }

    }

}
