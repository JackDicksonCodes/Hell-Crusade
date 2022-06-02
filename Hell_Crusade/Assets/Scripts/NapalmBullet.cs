using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NapalmBullet : MonoBehaviour
{
    
    public GameObject fire;
    private float fireTimer;
    private PlayerHealth playerHealth;


    void Start()
    {
        
        fireTimer = 0.12f;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireTimer <= 0){
            GameObject fireFloor = Instantiate(fire, gameObject.transform.position, gameObject.transform.rotation);
            fireTimer = 0.12f;
        }
        else if(fireTimer > 0){
            fireTimer -= Time.deltaTime;
        }
        
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
