using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJump : MonoBehaviour
{
    public float jumpUp = 5f;

    public float duration = 10f; //Duration of the PowerUp.

    public AudioSource PowerUpJumpFX;

    public GameObject pickupEffect;
    public GameObject PowerNotif;

    void OnTriggerEnter (Collider JumpUp)
    {
        if (JumpUp.CompareTag("Player"))
        {
            PowerNotif.SetActive(true);
            StartCoroutine(PickupJump(JumpUp));
        }
    }

    IEnumerator PickupJump(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PowerUpJumpFX.Play();

        //Increase Speed.
        PlayerScript jump = player.GetComponent<PlayerScript>();
        jump.jumpHeight += jumpUp;

        //So that this GameObject will not spawn back after Picking up.
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Waiting x amount of Seconds.
        yield return new WaitForSeconds(duration);

        //Back to Original Speed.
        jump.jumpHeight -= jumpUp;

        Destroy(gameObject);
        PowerNotif.SetActive(false);
    }
}
