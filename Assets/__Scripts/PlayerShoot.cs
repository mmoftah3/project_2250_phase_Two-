using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Player;
    public SpriteRenderer spriteRenderer;
    public Sprite Shooting;
    public Sprite Standing; 
    
    //update method
    void Update()
    {
        //Allow the method to run if the key
        if ( Input.GetKeyDown( KeyCode.LeftShift ) ) { 
             StartCoroutine(waiter());
        }
    }//end of update method
    
    //method with a timer that runs the shooting and animation
    IEnumerator waiter() {
        //change the image to gun
        spriteRenderer.sprite = Shooting;

        //fire gun
        GameObject bullet = Instantiate(BulletPrefab,Player.transform.position,Quaternion.identity);

        //wait one sec then change back
        yield return new WaitForSeconds(1);       
        spriteRenderer.sprite = Standing;
    }//end of waiter
}//end of class
