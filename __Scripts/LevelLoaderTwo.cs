using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoaderTwo : MonoBehaviour
{
    //on trigger method 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        //if the object collides with the player 
        if (collisionGameObject.name == "PlayerLv2")
        {
            //call the LoadScene() method 
            SceneManager.LoadScene(4);
            // LoadScene();
        }



    }
}
