using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    //Increases the health of the player
    void OnTriggerEnter(Collider other)
    {
        Health.heart += 1;
        gameObject.SetActive(false);
    }

    void  OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Health.heart += 1;
            gameObject.SetActive(false);
        }
    }
}
