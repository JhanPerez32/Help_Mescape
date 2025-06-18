using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    Rigidbody ShatterRB;

    public bool isExplosive;
    public bool PlayerHit;

    public GameObject DestroyEffect;

    private void Awake()
    {
        ShatterRB = GetComponent<Rigidbody>();

        if (isExplosive)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
            foreach (Collider col in colliders)
            {
                Rigidbody ShatterRB = col.GetComponent<Rigidbody>();
                if (ShatterRB != null)
                {
                    if (!ShatterRB.gameObject.tag.Equals("Player"))
                    {
                        float randomSize = Random.Range(.2f, .8f);
                        col.gameObject.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
                        ShatterRB.AddExplosionForce(7f, transform.position, 2f);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Instantiate(DestroyEffect, transform.position, transform.rotation);
            PlayerHit = true;
            Destroy(gameObject);
        }
        StartCoroutine(AfterShatter());
    }

    IEnumerator AfterShatter()
    {
        yield return new WaitForSeconds(25);

        Destroy(gameObject);
    }

    private void FixedUpdate()
    { 
        if (ShatterRB.position.y < -100f)
        {
            Instantiate(DestroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
