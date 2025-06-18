using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHard : MonoBehaviour
{
    public AudioSource DestroySFX;
    public GameObject HitEffect;
    public GameObject destroyedVersion;

    public float rotatespeedx = 25;
    public float rotatespeedy = 25;
    public float rotatespeedz = 25;

    public bool Hit = false;
    public bool ObsHit = false;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Hit = true;
            DestroySFX.Play();//Explosion Sound FX
            Instantiate(HitEffect, transform.position, transform.rotation);
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);

        }else if (collision.gameObject.tag.Equals("Obstacle"))
        {
            ObsHit = true;
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
}
