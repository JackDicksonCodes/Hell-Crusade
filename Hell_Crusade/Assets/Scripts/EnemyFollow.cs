using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    
    public Transform playerPosition;
    UnityEngine.AI.NavMeshAgent agent;

    // void Awake(){
    //     playerPosition = GameObject.FindGameObjectWithTag("Player").Transform;
    //     }

    // Start is called before the first frame update
    void Start()
    {   
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Vector2.Distance(transform.position, playerPosition.position) > 0.25f)
        // transform.position = Vector2.MoveTowards(transform, playerPosition, speed * Time.deltaTime);
        agent.destination = playerPosition.position;
        // transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed *Time.deltaTime);
    }

  
        
    
}
