using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDetection : MonoBehaviour
{
   private GameObject player;
    public Transform radar;
    private Vector3 rayDir;
    private int mask;
    private float counter;
    private bool aiSwitch;
    private EnemyMelleeCombatAi combatAi;
    private EnemyIdleAi idleAi;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Player");
        aiSwitch = false;
        mask = LayerMask.GetMask("Player");
        combatAi = gameObject.GetComponent<EnemyMelleeCombatAi>();
        idleAi = gameObject.GetComponent<EnemyIdleAi>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        

        rayDir = transform.TransformDirection(player.transform.position - radar.transform.position);
        if(Physics2D.Raycast(radar.transform.position, rayDir, 8f, mask)){
           ChangeToCombat();
            counter = 3;
            aiSwitch = true;
        }
        else if(counter > 0){
            counter -= Time.deltaTime;
        }
        else if(counter <= 0 && aiSwitch){
            ChangeToIdle();
            aiSwitch = false;
        }
    }

    public void ChangeToCombat(){
        agent.ResetPath();
        combatAi.isInCombat = true;
        idleAi.isPatroling = false;
    }

    public void ChangeToIdle(){
        agent.ResetPath();
        combatAi.isInCombat = false;
        idleAi.isPatroling = true;
    }
}
