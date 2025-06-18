using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowConvo : MonoBehaviour
{
    public float duration = 5;

    public GameObject MescapeConvo;

    void Start()
    {
        MescapeConvo.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            MescapeConvo.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec() //Message only Visible at the Amount of time
    {
        yield return new WaitForSeconds(duration);
        Destroy(MescapeConvo);
        Destroy(gameObject);
    }
}
