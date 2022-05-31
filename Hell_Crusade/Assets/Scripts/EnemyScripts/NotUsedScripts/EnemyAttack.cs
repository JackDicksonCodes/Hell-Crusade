using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerHealth health;
    public int attackDamage;

    

    //Damages Players on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player")){
            health = collision.gameObject.GetComponent<PlayerHealth>();
            health.ReceiveDamage(attackDamage);
        }
    }
}
