using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f; // The speed in m/s
    public GameObject canvasText;


    void Start()
    {
        canvasText.SetActive(false);
    }

   

    //This is a Property: A method that acts like a field
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    //Enemy_1 Movement
    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y += speed * Time.deltaTime;
        pos = tempPos;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            canvasText.SetActive(true);
        }

    }

}

