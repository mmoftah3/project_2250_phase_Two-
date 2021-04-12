using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //variables
    public float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;


    //start method
    void Start()
    {
        health = maxHealth;
        // slider.value = CalculateHealth();
    }//end of start method

    //update method
    void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);

        }
        if (health <= 0)
        {
            Destroy(gameObject);


        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }//end of update method

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(30);
        }
    }


}