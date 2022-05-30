using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool isRadarOn {get; set;}
    private GameObject player;
    public Transform radar;
    private Vector3 rayDir;
    private int mask;

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Player");
        isRadarOn = true;
        mask = LayerMask.GetMask("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isRadarOn){
            rayDir = transform.TransformDirection(player.transform.position - radar.transform.position);
            if(Physics2D.Raycast(radar.transform.position, rayDir, 8f, mask)){
                gameObject.GetComponent<EnemyCombatAI>().isInCombat = true;
                
            }
            
        }
    }
}
