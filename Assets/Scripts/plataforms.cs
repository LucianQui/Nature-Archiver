using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforms : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 2.0f; 
    private bool movingToB = true; 

    void Update()
    {
        if (movingToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            if (transform.position == pointB.position)
            {
                movingToB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            if (transform.position == pointA.position)
            {
                movingToB = true;
            }
        }
    }

    public void Interact() 
    { 
        movingToB = !movingToB; 
    }
}