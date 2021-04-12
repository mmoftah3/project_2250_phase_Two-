using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Vector3 velocity = new Vector3(10f, 0f, 0f);

    public bool moving = true;
    public int count = 0;

    void FixedUpdate()
    {
        if (moving)
        {
            if (count< 120)
            {
                transform.position += (velocity * Time.deltaTime);

            }
            else if (120 <= count && count<240)
            {
                transform.position -= (velocity * Time.deltaTime);
            }
            else
            {
                count = 0;
            }


            count = count + 1;
        }
    }


}
