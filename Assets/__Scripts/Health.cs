using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //declaring variables
    public GameObject health1, health2, health3, gameOver;
    public static int heart;

    private playerMovement shield;

    // Start is called before the first frame update
    void Start()
    {
        heart = 3;
        health1.SetActive(true);
        health2.SetActive(true);
        health3.SetActive(true);
        gameOver.SetActive(false);

        shield = GetComponent<playerMovement>();

    }

    void Update()
    {
        if (heart == 3)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(false);

        }

        else if (heart == 2)
            {
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);

        }
        else if (heart == 1)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);

        }
        else if (heart == 0)
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shield.ActiveShield)
        {
            if (collision.tag == "Enemy")
            {
                heart -= 1;
            }
        }

    }*/
}
