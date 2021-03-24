using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//grounded class inherits from the player movement class 
//grounded akes sure that the player jumps only when it's on the platforms
 
public class Grounded : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player1; 
    void Start()
    {
        //to get the player
        Player1 = gameObject.transform.parent.gameObject; 
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            //if it's grounded it can jump 
            //inherits from the player movement class 
            Player1.GetComponent<playerMovement>().isGrounded = true; 
        }
    }

    //on collision exit method 
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            
        {
            //if it's not grounded then it can't jump 
            Player1.GetComponent<playerMovement>().isGrounded = false;
        }

    }
}
