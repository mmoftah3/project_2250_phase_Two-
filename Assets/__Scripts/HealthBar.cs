using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : EnemyHealth
{
    
    void TakeDamage(int damage)
    {
        if(playerMovement.shieldActive== true){
            damage = damage - 10;
        }
        health -= damage;
    }
    void AddHealth(int hp)
    {
        health += hp;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }
        if (collision.collider.CompareTag("HealthBox"))
        {
            AddHealth(40);
            Destroy(collision.gameObject);
        }
    }
}
