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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
        isPatroling = true;
        patrolStart = false;
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
}
