using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public AudioSource SpawnSFX;

    public Transform SpawnObstaclePoint;

    public GameObject ObstacleCloneSpawn;
    public GameObject SpawnFX;

    public bool player = false;

    private void OnCollisionEnter(Collision PlayerPass)
    {
        if (PlayerPass.gameObject.tag.Equals("Player"))
        {
            player = true;
            SpawnSFX.Play();
            Instantiate(SpawnFX, transform.position, transform.rotation);
            Instantiate(ObstacleCloneSpawn, SpawnObstaclePoint.position, SpawnObstaclePoint.rotation);
        }
    }
}
