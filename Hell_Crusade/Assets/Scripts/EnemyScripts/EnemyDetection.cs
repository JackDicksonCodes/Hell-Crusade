using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private GameObject player;
    public Transform radar;
    private Vector3 rayDir;
    private int mask;
    private int counter;
    private bool aiSwitch;

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Player");
        aiSwitch = false;
        mask = LayerMask.GetMask("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        

        rayDir = transform.TransformDirection(player.transform.position - radar.transform.position);
        if(Physics2D.Raycast(radar.transform.position, rayDir, 8f, mask)){
            gameObject.GetComponent<EnemyCombatAI>().isInCombat = true;
            gameObject.GetComponent<EnemyIdleAi>().isPatroling = false;
            counter = 5;
            aiSwitch = true;
        }
        else if(counter > 0){
            counter -= 1;
        }
        else if(counter == 0 && aiSwitch){
            gameObject.GetComponent<EnemyCombatAI>().isInCombat = false;
            gameObject.GetComponent<EnemyIdleAi>().isPatroling = true;
            aiSwitch = false;
        }
    }
}
