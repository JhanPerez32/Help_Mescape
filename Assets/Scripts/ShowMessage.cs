using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{
    public GameObject MescapeMessage;

    void Start()
    {
        MescapeMessage.SetActive(false);
    }


    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            MescapeMessage.SetActive(true);
            //StartCoroutine("WaitForSec");
        }
    }

    void OnTriggerExit(Collider player)
    {
        MescapeMessage.SetActive(false);
    }

    /*IEnumerator WaitForSec() //Message only Visible at the Amount of time
    {
        yield return new WaitForSeconds(25);
        Destroy(MescapeMessage);
        Destroy(gameObject);
    }*/
}
