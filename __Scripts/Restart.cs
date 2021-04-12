using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    //method to main menu
    public void restartGame()
    {
        //loading main meanu that has index 3
        SceneManager.LoadScene(3);
    }
}
