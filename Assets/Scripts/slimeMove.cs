using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeMove : MonoBehaviour
{
    public float speed = 2.0f; 
    public Transform pointA; 
    public Transform pointB; 
    private bool movingToB = true;     
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (movingToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            animator.SetBool("isMovingRight", true); 
            animator.SetBool("isMovingLeft", false); 

            if (transform.position == pointB.position)
            {
                movingToB = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            animator.SetBool("isMovingRight", false); 
            animator.SetBool("isMovingLeft", true); 

            if (transform.position == pointA.position)
            {
                movingToB = true;
            }
        }
        
    }
    
}

