using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    //variable to use i level 
    public int iLevelToLoad;
    //variable to have the load the same level
    public string sLevelToLoad;
    //to use the number of the level 
    public bool useIntegerToLoadLevel = false;
    // Start is called before the first frame update

  

    //on trigger method 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        //if the object collides with the player 
        if (collisionGameObject.name == "Player")
        {
            //call the LoadScene() method 
            SceneManager.LoadScene(3);
           // LoadScene();
        }



    }

    //LoadScene() method to load the new level 
    void LoadScene()

    {
        //if useIntegerToLoadLevel is true 
        if (useIntegerToLoadLevel)
        {
            //load the new level 
            SceneManager.LoadScene(iLevelToLoad); //load this certain level
        }
        //load it to the same level
        else
        {
            //load the same level 
            SceneManager.LoadScene(sLevelToLoad); 
        }

    }
    

    
}
