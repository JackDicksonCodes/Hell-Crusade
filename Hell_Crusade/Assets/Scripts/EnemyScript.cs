using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 2;

    // Update is called once per frame
    void Update()
    {
        if(health == 0){
            
            Destroy(gameObject);
        }
    }

    void takeHit(int damage){
        health -= damage;
    }
}
