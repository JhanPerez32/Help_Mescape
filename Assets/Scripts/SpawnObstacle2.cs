using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle2 : MonoBehaviour
{
    public float duration = 2;

    [SerializeField] private Animator OBSLeft;
    [SerializeField] private Animator OBSRight;

    private void OnTriggerEnter(Collider Player)
    {
        if (Player.CompareTag("Player"))
        {
            OBSLeft.SetBool("MoveLeft", true);
            OBSRight.SetBool("MoveRight", true);
            
            StartCoroutine(AfterSpawn());
        }
    }

    IEnumerator AfterSpawn()
    { 
        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
    }
}
