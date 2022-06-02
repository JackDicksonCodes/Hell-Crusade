using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemyDetection : MonoBehaviour
{
    private GameObject player;
    public Transform radar;
    public ExplodingEnemyScript ExplodingEnemyScript;
    private Vector3 rayDir;
    private int mask;
    private float counter;
    private bool aiSwitch;
    private EnemyExplode combatAi;
    private EnemyIdleAi idleAi;

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Player");
        aiSwitch = false;
        mask = LayerMask.GetMask("Player");
        combatAi = gameObject.GetComponent<EnemyExplode>();
        idleAi = gameObject.GetComponent<EnemyIdleAi>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!ExplodingEnemyScript.getIsDead())
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
    }
    public void ChangeToCombat(){
        combatAi.isInCombat = true;
        idleAi.isPatroling = false;
    }

    public void ChangeToIdle(){
        combatAi.isInCombat = false;
        idleAi.isPatroling = true;
    }
}
