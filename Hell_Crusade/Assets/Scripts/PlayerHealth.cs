using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    //This is for a health bar that appears on the UI
    public HealthBarScript healthBar;

    public void ReceiveDamage(int attackDamage){
        currentHealth -= attackDamage;
        healthBar.SetHealth(currentHealth);
    }

    void Start(){
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }

}
