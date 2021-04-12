using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemy : MonoBehaviour
{

    public float speed; //speed
    public float stoppingDistance; //stopping distance
    public float retreatDistance;  //retreat distance 
    public float attackRange; //atk range
    public bool isFlipped;

    public Sprite[] enemy;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile; //fireball
    private Transform player; //player

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //find player object

        timeBtwShots = startTimeBtwShots;

        isFlipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) //if greater than stopping distance then move towards player
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) //if greater than retreat distance then dont move
        {

        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance) //if smaller than retreat distance then move away from player
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed);


        }

        if (timeBtwShots <= 0 && Vector2.Distance(transform.position, player.position) < attackRange) //if within attack range and time between shots is 0 then launch fire ball
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemy[1];  //if inside attack range, holds gun
            Instantiate(projectile, transform.position, Quaternion.identity);  
            timeBtwShots = startTimeBtwShots;
        }
        else if (Vector2.Distance(transform.position, player.position) < attackRange) //if within attack range and time between shots is greater than 0 then do not launch fireball
        {
            timeBtwShots -= Time.deltaTime;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemy[1];  //if inside attack range, holds gun
        }
        else if(Vector2.Distance(transform.position, player.position) > attackRange)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enemy[0];  //if outside attack range then idle
        }

        LookAtPlayer();


        //shots
    }



    void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
