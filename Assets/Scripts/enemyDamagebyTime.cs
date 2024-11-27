using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamagebyTime : MonoBehaviour
{
    public int damageAmount = 15; 
    public float damageInterval = 0.3f; 
    private float nextDamageTime; 

    void Start()
    {
        nextDamageTime = Time.time;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= nextDamageTime)
            {
                playerHealth playerHealth = collision.gameObject.GetComponent<playerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                    nextDamageTime = Time.time + damageInterval; 
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextDamageTime = Time.time; 
        }
    }
}


