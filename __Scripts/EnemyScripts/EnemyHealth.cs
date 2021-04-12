using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //variables
    public float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;

    public EXP exp;

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
            exp.gainXP(30);
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
