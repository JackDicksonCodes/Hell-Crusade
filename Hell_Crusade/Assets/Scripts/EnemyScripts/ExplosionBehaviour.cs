using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    PlayerHealth playerHealth;

    private float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0){
            timer -= Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player"))
        {
            playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            playerHealth.ReceiveDamage(5);
            // Destroy(gameObject);

        }
    }
}
