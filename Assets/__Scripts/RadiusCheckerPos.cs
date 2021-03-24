using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusCheckerPos : MonoBehaviour
{
    public float speed = 60; 
    
    void Update() {
        Move();
    }
    //move method
    public void Move(){
        Vector3 tempPos = pos;
        tempPos.x += speed *Time.deltaTime;
        pos = tempPos;
    }//end of move method

    //position method
    public Vector3 pos {
        get {
            return(this.transform.position);
        }
        set {
            this.transform.position = value; 
        }
    }//end of position
}
