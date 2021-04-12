using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move2d : MonoBehaviour
{
    public float moveSpeed = 5f;


    private void Update()
    {
        //to make the player move 
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }



}


