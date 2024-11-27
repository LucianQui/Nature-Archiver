using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    public plataforms platform; 
    private bool playerInRange = false; 

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            platform.Interact(); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}


