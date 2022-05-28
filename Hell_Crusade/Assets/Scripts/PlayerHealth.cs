using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public void ReceiveDamage(int attackDamage){
        currentHealth -= attackDamage;
    }

    void Start(){
        currentHealth = maxHealth;
    }

}
