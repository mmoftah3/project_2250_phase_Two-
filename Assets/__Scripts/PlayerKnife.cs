using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnife : EnemyHealth
{
    //declaring variables
    public GameObject Player;
    public SpriteRenderer spriteRenderer;
    public Sprite stance1;
    public Sprite stance2; 
    public Sprite stance3;
    public Sprite Standing;
    public GameObject InvisRadpos;
    public GameObject InvisRadneg;

    
    //update method
    void Update()
    {
        // Allow the knife to swing if the key is pressed
        if (Input.GetKeyDown(KeyCode.Z)) { 
             StartCoroutine(waiter());
        }
    }//end of update method

    public void Hit() {
        GameObject Radiuspos = Instantiate(InvisRadpos,Player.transform.position,Quaternion.identity);
        GameObject Radiusneg = Instantiate(InvisRadneg,Player.transform.position,Quaternion.identity);
    }//end of hit method

    //method with timer in it
    IEnumerator waiter() {
        //cycle through the animation
        spriteRenderer.sprite = stance1; 

        yield return new WaitForSeconds(0.1f); 
        spriteRenderer.sprite = stance2; 

        yield return new WaitForSeconds(0.1f); 
        spriteRenderer.sprite = stance3; 

        //hit if enemy is there
        Hit();

        //bring knife down
        yield return new WaitForSeconds(0.2f); 
        spriteRenderer.sprite = stance2;

        yield return new WaitForSeconds(0.1f); 
        spriteRenderer.sprite = stance1;

        //then change back to standing image
        yield return new WaitForSeconds(0.1f);       
        spriteRenderer.sprite = Standing;
    }//end of waiter method
}//end of class
