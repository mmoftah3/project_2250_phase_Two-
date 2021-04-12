using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    //variables
    public float speed = 40; 
    public GameObject Player;
    public bool isNegShot;
    
    
    //start method to determine direction of bullet
    void Start(){
        isNegShot = playerMovement.isFlipped;
    }//end of start method

    //update method
    void Update(){
        Move();
        Bounds();
    }//end of update method

    //move method
    public void Move(){
        if(isNegShot == false) {
            Vector3 tempPos = pos;
            tempPos.x += speed *Time.deltaTime;
            pos = tempPos;
        }
        else {
            Vector3 tempPos = pos;
            tempPos.x -= speed *Time.deltaTime;
            pos = tempPos;
        }
    }//end of move method

    //destroys the bullet if it goes too far away
    public void Bounds(){
        if(gameObject.transform.position.x > (Player.transform.position.x + 200)){
            Destroy(gameObject);
        }
    }//end of bounds method

    //position method
    public Vector3 pos {
        get {
            return(this.transform.position);
        }
        set {
            this.transform.position = value; 
        }
    }//end of position

    //destroying the bullet and the enemy if it hits the enemy
    void OnTriggerEnter(Collider other) { 
        if (other.gameObject.tag == "Enemy") { 
        Destroy(gameObject);
        }//end of if statement
    }//end of on trigger method
}//end of bullet shooting class