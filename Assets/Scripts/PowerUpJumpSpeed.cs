using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJumpSpeed : MonoBehaviour
{
    public float SpeedUp = 10f;
    public float JumpUp = 10f;

    public float duration = 5f; //Duration of the PowerUp.

    public AudioSource PowerUpJumpSpeedFX;

    public GameObject pickupEffect;
    public GameObject PowerNotif;

    void OnTriggerEnter (Collider JumpSpeedUp)
    {
        if (JumpSpeedUp.CompareTag("Player"))
        {
            PowerNotif.SetActive(true);
            StartCoroutine(PickJumpSpeedUP(JumpSpeedUp));
        }
    }

    IEnumerator PickJumpSpeedUP (Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PowerUpJumpSpeedFX.Play();

        //Increase Speed and Jump.
        PlayerScript speed = player.GetComponent<PlayerScript>();
        speed.moveSpeed += SpeedUp;

        PlayerScript jump = player.GetComponent<PlayerScript>();
        jump.jumpHeight += JumpUp;

        //So that this GameObject will not spawn back after Picking up.
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Waiting x amount of Seconds.
        yield return new WaitForSeconds(duration);

        //Back to Original Speed.
        speed.moveSpeed -= SpeedUp;
        jump.jumpHeight -= JumpUp;

        Destroy(gameObject);
        PowerNotif.SetActive(false);
    }
}
