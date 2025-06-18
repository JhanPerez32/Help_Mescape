using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public bool PlayerPresent = false;

    public GameObject Access;

    void Start()
    {
        Access.SetActive(false);
    }

    private void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.tag.Equals("Player"))
        {
            PlayerPresent = true;
            Access.SetActive(true);
        }
    }
}
