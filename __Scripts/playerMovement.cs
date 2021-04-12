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
    public Sprite Crouching;
    private BoxCollider2D collider2D;
    Sprite Current;
    public bool isGrounded = false;
    public GameObject shield;
    public Text countText;
    public static bool shieldActive = false;
    private int count;
    public static bool isFlipped = false;
    public static bool isCrouch = false;
    public float jumpSpeed = 10f;
    //public Text leveltext; 
    public bool higherAnimationCrouch = false;

    //start method
    void Start(){

        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WaiterWalk());
        shield.SetActive(false);

    }//end of the start method
    
    //update method
    void Update()
    {
        SetCountText();
       // setLevelText(); 
        Jump();
        Flip();
        if (Input.GetKeyDown(KeyCode.C))
        {
            spriteRenderer.sprite = Crouching;
            higherAnimationCrouch = true;
        }
        else {higherAnimationCrouch = false;}
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed; 
        
    }//end of update method
   
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
                if(!(higherAnimationCrouch)){
                    yield return new WaitForSeconds(0.5f);   
                    //changing image to walking
                    ChangeSpriteWalk();
                    //wait one sec then change back
                    yield return new WaitForSeconds(0.5f);       
                    ChangeSpriteStand();
                    Current = spriteRenderer.sprite;
                }
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
        if(collision.gameObject.CompareTag("Box"))
        {
            shield.SetActive(true);
            shieldActive = true;
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
        countText.text = ("Count: " + count.ToString() +"                                                                 Level 1" );
    }

 


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

