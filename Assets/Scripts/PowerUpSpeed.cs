using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    public float speedUp = 10f;
    
    public float duration = 5f; //Duration of the PowerUp.

    public AudioSource PowerUpSpeedSFX;

    public GameObject pickupEffect;
    public GameObject PowerNotif;

    void Start()
    {
        PowerNotif.SetActive(false);
    } 

    void OnTriggerEnter (Collider SpeedUp)
    {
        if (SpeedUp.CompareTag("Player"))
        {
            PowerNotif.SetActive(true);
            StartCoroutine (PickupSpeed(SpeedUp));
        }
    }

    IEnumerator PickupSpeed (Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PowerUpSpeedSFX.Play();

        //Increase Speed.
        PlayerScript speed = player.GetComponent<PlayerScript>();
        speed.moveSpeed += speedUp;

        //So that this GameObject will not spawn back after Picking up.
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Waiting x amount of Seconds.
        yield return new WaitForSeconds(duration);

        //Back to Original Speed.
        speed.moveSpeed -= speedUp;
        
        Destroy(gameObject);
        PowerNotif.SetActive(false);
    }
}
