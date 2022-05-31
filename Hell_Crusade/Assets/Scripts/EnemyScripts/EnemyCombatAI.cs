using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatAI : MonoBehaviour
{

    public bool isInCombat {get; set;}
    UnityEngine.AI.NavMeshAgent agent;
    public Transform projexit;
    private GameObject player;
    public GameObject bloodProjectile;
    private float coolDown = 5f;
    private float activeCooldown;
    public float projectileForce = 10f;
    private float distance;
    private Vector3 rayDir;

    // Start is called before the first frame update
    void Start()
    {
        isInCombat = false;
        player = GameObject.Find("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(isInCombat == false){
            return;
        }
        else{
            move();
            fight();
            
        }
        
    }

    

    private void fight(){
        rayDir = transform.TransformDirection(player.transform.position - transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir);
        if(hit.collider.tag == "Player"){
            Shoot();
        }

        if(activeCooldown > 0){
            activeCooldown -= Time.deltaTime;
        }
    }

    private void Shoot(){
        if(activeCooldown <= 0){
            GameObject bullet = Instantiate(bloodProjectile, projexit.position, projexit.rotation);
            Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
            body.AddForce(rayDir * projectileForce, ForceMode2D.Impulse);
            activeCooldown = coolDown;
        }
    }

    private void move(){
        if(distance > 7)
        {
            agent.isStopped = false;
            agent.destination = player.transform.position;
           
        }
        else{
            agent.isStopped = true;
        }

    }

}
