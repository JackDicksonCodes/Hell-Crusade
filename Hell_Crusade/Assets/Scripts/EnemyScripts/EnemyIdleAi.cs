using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleAi : MonoBehaviour
{
    public List<Transform> points;
    private int destPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    public bool isPatroling;
    public bool patrolStart;
    private float differenceInX;
    private float previousX;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
        isPatroling = true;
        patrolStart = false;
        previousX = 0;
    }

    void GotoNextPoint(){
        if(points.Count == 0){
            return;
        }

        agent.destination = points[destPoint].position;

        if(destPoint == points.Count - 1){
            destPoint = 0;
        }
        else{
            destPoint ++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPatroling){
            if(patrolStart){
                GotoNextPoint();
                patrolStart = false;
            }
            else if(agent.remainingDistance == 0){
                GotoNextPoint();
            }
        }
    }

    private void FixedUpdate() {
        if(points.Count != 0 && isPatroling){
            differenceInX = previousX - gameObject.transform.position.x;
            if(differenceInX > 0.2){
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if(differenceInX < -0.2 && isPatroling){
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else{
                return;
            }
            previousX = gameObject.transform.position.x;
        }
        
    }
}
