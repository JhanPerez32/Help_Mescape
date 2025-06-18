using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject ExplosionFX;

    public float BulletSpeed = 100;

    public bool PlatformHit = false;
    public bool ObstacleHit = false;

    void Update()
    {
        transform.Translate(Vector3.right * BulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            PlatformHit = true;
            Instantiate(ExplosionFX, transform.position, transform.rotation);
            Destroy(gameObject);

        }else if (collision.gameObject.tag.Equals("Obstacle"))
        {
            ObstacleHit = true;
            Instantiate(ExplosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

}
