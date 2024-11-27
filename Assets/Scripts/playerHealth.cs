using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth; 
    public Slider healthBar; 
    public Transform respawnPoint;
    private itemCollector itemCollector;
    private Animator animator;
   

    void Start()
    {
        currentHealth = maxHealth; 
        healthBar.maxValue = maxHealth; 
        healthBar.value = currentHealth;
        itemCollector = GetComponent<itemCollector>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 
        healthBar.value = currentHealth; 

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ResestCharacterStats();
        transform.position = respawnPoint.position; 
        currentHealth = maxHealth; 
        healthBar.value = currentHealth;
        itemCollector.ResetCollectedItems();
    }
    
    void ResestCharacterStats()
    {
        transform.localScale = new Vector3(1,1,1);
        animator.SetBool("walking", false);
    }
}




