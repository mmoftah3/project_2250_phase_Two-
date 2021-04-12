using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    //method to load the first scene
   public void playGame()
    {
        //loading level 1 that has index 0
        SceneManager.LoadScene(0); 
    }

    //method to quit the game 
    public void quitGame()
    {
        //quit the game 
        Application.Quit(); 
    }
}
