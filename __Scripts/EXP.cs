using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour
{
    //variables
    public float xp;
    public float maxXp;
    public GameObject expBarUI;
    public Slider slider;

    public HealthBar health;




    //start method
    void Start()
    {
        xp = 0;
        // slider.value = CalculateHealth();
    }//end of start method

    //update method
    void Update()
    {
        slider.value = CalculateXP();

        if (xp < maxXp)
        {
            expBarUI.SetActive(true);

        }

        if (xp > maxXp)
        {
            xp = 0;
            health.setMaxHealth();
            health.AddHealth(50);
        }


    }//end of update method

    float CalculateXP()
    {
        return xp / maxXp;
    }

    public void gainXP(int exp)
    {
        xp += exp;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "exp")
        {
            gainXP(40);
            Destroy(collision.gameObject);
        }
    }

}
