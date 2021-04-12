using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour
{
    //variables
    public float xp;
    public float maxXp;
    public GameObject healthBarUI;
    public Slider slider;
    

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
            healthBarUI.SetActive(true);

        }
      
        if (xp > maxXp)
        {
            xp = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gainXP(10);
        }
    }//end of update method

    float CalculateXP()
    {
        return xp / maxXp;
    }

    void gainXP(int exp)
    {
        xp += exp;
    }

}
