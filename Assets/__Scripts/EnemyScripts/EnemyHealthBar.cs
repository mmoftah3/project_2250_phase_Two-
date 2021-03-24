using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : EnemyHealth
{
    void TakeDamage(int damage)
    {
  
        health -= damage;
    }
  

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(30);
        }

        if (collision.gameObject.tag == "Player" && PlayerKnife.isHitting == true)
        {
            TakeDamage(20);
        }
    }
}
