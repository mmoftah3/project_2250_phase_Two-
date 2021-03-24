using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusChecker : MonoBehaviour
{
    //variables
    public GameObject Player;

    //update method
    void Update(){
        Bounds();
    }//end of update method

    //destroys the bullet if it goes too far away
    public void Bounds(){
        if(gameObject.transform.position.x > (Player.transform.position.x + 2)||gameObject.transform.position.x < (Player.transform.position.x - 2)){
            Destroy(gameObject);
        }
    }//end of bounds method

    //destroying the bullet and the enemy if it hits the enemy
    void OnTriggerEnter(Collider other) { 
        if (other.gameObject.CompareTag("Enemy")) { 
        Destroy(other.gameObject);
        Destroy(gameObject);
        }//end of if statement
    }//end of on trigger method
}
