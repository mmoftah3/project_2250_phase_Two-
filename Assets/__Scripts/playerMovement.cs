using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    //declaring variables
    public float moveSpeed = 5f; 
    public SpriteRenderer spriteRenderer;
    public Sprite Walking;
    public Sprite Standing;
    Sprite Current;
    public bool isGrounded = false;
    public GameObject shield;
    public Text countText;


    private int count;

    //start method
    void Start(){
     
        StartCoroutine(WaiterWalk());
        shield.SetActive(false);

    }//end of the start method
    
    //update method
    void Update()
    {
        SetCountText();
        Jump(); 
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed; 
        
    }//end of update method

    //jump method
    void Jump()
    {
        //making player jump if space is pressed
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            //change image to jumping one when we have the image
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse); 
            

        }//end of if statement
    }//end of jump method

    IEnumerator WaiterWalk() {
        while(true){   
            Current = spriteRenderer.sprite;
            yield return new WaitForSeconds(0.5f);   
            while(!(Current.name == "GuyWithGun") && isGrounded==true){
                yield return new WaitForSeconds(0.5f);   
                //changing image to walking
                ChangeSpriteWalk();
                //wait one sec then change back
                yield return new WaitForSeconds(0.5f);       
                ChangeSpriteStand();
                Current = spriteRenderer.sprite;
            }
        }
    }//end of waiter method

    //methods to change sprites images
    void ChangeSpriteWalk() {
        spriteRenderer.sprite = Walking; 
    }

    void ChangeSpriteStand() {
        spriteRenderer.sprite = Standing; 
    }

    void  OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true; 
        }
        //To collect gems
        if(collision.gameObject.CompareTag("Gems"))
        {
            Destroy(collision.gameObject);
            //Increase the number of gems
            count += 1;
        }
        if(collision.gameObject.CompareTag("Box"))
        {
            shield.SetActive(true);
        }
        if (collision.collider.CompareTag("HealthBox"))
        {
            Destroy(collision.gameObject);
            Health.heart += 1; 
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
         if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }

    }

    void SetCountText()
    {
        //Display the score of the game
        countText.text = "Count: " + count.ToString();

    }

    //method to make the geems dissapaear 
    private void OnTriggerEnter(Collider other)
    {
        //if the tag of the object is Gems
        if (other.gameObject.CompareTag("Gems"))
        {
            other.gameObject.SetActive(false); //to disable the gems and make it dissapear
            count = count + 5;//cubes are worth 5 points

            SetCountText();
        }

    }
}//end of class
