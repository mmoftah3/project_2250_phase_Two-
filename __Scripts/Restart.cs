using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    //method to load main menu
    public void restartGame()
    {
        //loading main meanu that has index 2
        SceneManager.LoadScene(2);
    }
}
