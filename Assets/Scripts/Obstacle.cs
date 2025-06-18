using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody ObstacleRigidbody;

    public AudioSource DestroySFX;
    public GameObject HitEffect;
    public GameObject destroyedVersion;

    public float rotatespeedx = 95;
    public float rotatespeedy = 150;
    public float rotatespeedz = 200;
    
    public bool Hit = false;

    private void Awake()
    {
        ObstacleRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Hit = true;
            DestroySFX.Play();//Explosion Sound FX
            Instantiate(HitEffect, transform.position, transform.rotation);
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

    void Update()
    {
        transform.Rotate(rotatespeedx * Time.deltaTime, rotatespeedy * Time.deltaTime, rotatespeedz * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (ObstacleRigidbody.position.z >= 25f)
        {
            DestroyObstacle();

        }
        else if (ObstacleRigidbody.position.z <= -25f)
        {
            DestroyObstacle();

        }
        else if (ObstacleRigidbody.position.y >= 150f)
        {
            DestroyObstacle();

        }
        else if (ObstacleRigidbody.position.y <= -150f)
        {
            DestroyObstacle();

        }
    }

    void DestroyObstacle()
    {
        DestroySFX.Play();//Explosion Sound FX
        Instantiate(HitEffect, transform.position, transform.rotation);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
