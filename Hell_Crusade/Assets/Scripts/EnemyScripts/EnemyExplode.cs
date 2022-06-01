using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    public bool isInCombat {get; set;}
    UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;

    public GameObject explosionObject;
    public Transform explosionOrigin;

    private float distance;
    private Vector3 rayDir;

    // public int explosionDamage;
    public float triggerRange; //range before enemy stops and explodes

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
            agent.speed = 3;
            return;
        }
        else{
            agent.speed = 6;
            move();
            
        }
    }
    
        private void move(){
        if(distance > triggerRange)
        {
            agent.isStopped = false;
            agent.destination = player.transform.position;
           
        }
        else{
            agent.isStopped = true;
            //explode
            Debug.Log("Within range");
            GameObject explosion = Instantiate(explosionObject, explosionOrigin.position, explosionOrigin.rotation);
            Destroy(gameObject);
        }
    }

    public void spawnExplosion(){
        GameObject explosion = Instantiate(explosionObject, explosionOrigin.position, explosionOrigin.rotation);
    }
}