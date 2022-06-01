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

    void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
            health -= 1;
            FindObjectOfType<EnemyDetection>().ChangeToCombat();
        }
        
    }

    private void OnDestroy() 
    {
        if(FindObjectOfType<DoorBehaviour>()){
            FindObjectOfType<DoorBehaviour>().removeEnemy(gameObject);
        }
    }
}
