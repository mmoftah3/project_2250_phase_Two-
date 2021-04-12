using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveTwo : MonoBehaviour
{
    //method to load level two 
    public void playLevelTwo()
    {
        //loading level 2 that has index 1
        SceneManager.LoadScene(1);
    }
}
