using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovementPlayer2 : MonoBehaviour
{
  

    //declaring variables
    public float moveSpeed = 5f; 
    public SpriteRenderer spriteRenderer;
    public Sprite Walking;
    public Sprite Standing;
    public Sprite Crouching;
    private BoxCollider2D collider2D;
    Sprite Current;
    public bool isGrounded = false;
    public GameObject shield;
    public Text countText;
    public static bool shieldActive = false;
    private int count;
    private int countLv2;
    public static bool isFlipped = false;
    public static bool isCrouch = false;
    public static bool jetpackActive = false;
    public GameObject jetpack;
    public float jetpackSpeed = 10f;
    public float jumpSpeed = 10f;
    //public Text leveltext; 

    //start method
    void Start(){

        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WaiterWalk());
        shield.SetActive(false);
        jetpack.SetActive(false);

    }//end of the start method
    
    //update method
    void Update()
    {
        SetCountText();
        //setLevelText(); 
        Jump();
        Flip();
        Jetpack();
        if (Input.GetKeyDown(KeyCode.C))
        {
            spriteRenderer.sprite = Crouching;
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed; 
        
    }//end of update method
   
    
    void Jetpack(){
        //making player use jetpack if g is pressed
        if (Input.GetKeyDown(KeyCode.G) && jetpackActive == true){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jetpackSpeed), ForceMode2D.Impulse);
        }//end of if statement
    }

    //jump method
    void Jump()
    {
        //making player jump if space is pressed
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            //change image to jumping one when we have the image
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
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

    void ChangeSpriteCruching()
    {
        spriteRenderer.sprite = Crouching;
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
        if(collision.gameObject.CompareTag("Gems2"))
        {
            Destroy(collision.gameObject);
            //Increase the number of gems2
            countLv2 += 1;
        }
        if(collision.gameObject.CompareTag("Box"))
        {
            shield.SetActive(true);
            shieldActive = true;
        }
        if(collision.gameObject.CompareTag("JetpackBox"))
        {
            jetpack.SetActive(true);
            jetpackActive = true;
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
        countText.text = ("Count: " + count.ToString() + "\nCount: " + countLv2.ToString() + "                                  " +
            "                                       Level 2");
    }

    /*void setLevelText()
    {
        leveltext.text = ("Level: " + count.ToString());

    }*/




    //This will flip the player if you push F.
    void Flip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFlipped)
            {  //flips if false
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else
            { //flips if true

                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }

        }

    }
}//end of class

