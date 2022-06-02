using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player"))
        {
            playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerHealth.ReceiveDamage(5);
            Destroy(gameObject);

        }
        else if(col.gameObject.tag.Equals("Wall")){
            Destroy(gameObject);
        }
    }
}
