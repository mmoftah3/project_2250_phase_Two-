
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);

        }
        if (health <= 0)
        {
            resetGame();
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

   public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dagger")
        {
            TakeDamage(20);
        }
    }
    void resetGame()
    {
        Thread.Sleep(2500); //Pause before reset.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //restarts game
    }


}
