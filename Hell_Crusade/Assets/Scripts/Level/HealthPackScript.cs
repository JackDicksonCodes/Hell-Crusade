using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackScript : MonoBehaviour
{
    public int healAmount;
    private PlayerHealth playerHealth;


    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player")){
            playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerHealth.heal(healAmount);
            Destroy(gameObject);
        }
    
    }
}
