using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public Transform playerPosition;
    public float projectileForce = 5f;
    public Transform projexit;
    private float coolDown = 5f;
    private float activeCooldown;
    private Vector3 rayDir;
    public GameObject bloodProjectile;
    // Start is called before the first frame update
    void Start()
    {
        activeCooldown = 0f;
    }

    // Update is called once per frame
   void Update()
    {   
        
        rayDir = transform.TransformDirection(playerPosition.transform.position - transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir);
        if(hit.collider.tag == "Player"){
            Shoot();
        }

        if(activeCooldown > 0){
            activeCooldown -= Time.deltaTime;
        }
        // Debug.Log(activeCooldown);
        
    }

    void Shoot(){
        if(activeCooldown <= 0){
            GameObject bullet = Instantiate(bloodProjectile, projexit.position, projexit.rotation);
            Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
            body.AddForce(rayDir * projectileForce, ForceMode2D.Impulse);
            activeCooldown = coolDown;
        }
    }
}
