using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public int damageAmount = 15; 

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth playerHealth = collision.gameObject.GetComponent<playerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); 
            }
        }
    }
}


