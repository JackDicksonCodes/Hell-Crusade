using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int health = 2;

    // Update is called once per frame
    void Update()
    {
        if(health == 0){
            
            Destroy(gameObject);
            
        }
    }

    void OnCollisionEnter2D(Collision2D col) {

        if(col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
            health -= 1;
        }
        
    }
}
