using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    //variables
    public float speed = 40; 
    public GameObject player;
    public bool isNegShot;
    public bool isNegShot2;
    
    
    //start method to determine direction of bullet
    void Start(){
        isNegShot = playerMovement.isFlipped;
        isNegShot2 = playerMovementPlayer2.isFlipped;
        player = GameObject.FindGameObjectWithTag("Player");
    }//end of start method

    //update method
    void Update(){
        Move();
        Bounds();
    }//end of update method

    //move method
    public void Move(){
        if(isNegShot == false && isNegShot2 == false) {
            Vector3 tempPos = pos;
            tempPos.x += speed *Time.deltaTime;
            pos = tempPos;
        }
        else if (isNegShot == true && isNegShot2 == false)
        {
            Vector3 tempPos = pos;
            tempPos.x -= speed * Time.deltaTime;
            pos = tempPos;
        }
        else if (isNegShot == false && isNegShot2 == true)
        {
            Vector3 tempPos = pos;
            tempPos.x -= speed * Time.deltaTime;
            pos = tempPos;
        }

       
        
      
    }//end of move method

    //destroys the bullet if it goes too far away
    public void Bounds(){
        if(gameObject.transform.position.x > (player.transform.position.x + 80)){
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
    void OnTriggerEnter (Collider other) { 
        if (other.gameObject.tag == "Enemy") { 
        Destroy(gameObject);
        }//end of if statement
    }//end of on trigger method
}//end of bullet shooting class