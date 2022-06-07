using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneBehaviour : MonoBehaviour
{
    private Camera cam;
    private GameObject boss;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        boss = GameObject.Find("TheEyeOfTerror");
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(boss.GetComponent<BossScript>().health == 4){
            cam.GetComponent<FollowPlayer>().changeFollow(player);
            boss.GetComponent<BossPhase1Behaviour>().StartPhase1();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            cam.GetComponent<FollowPlayer>().changeFollow(boss);
            boss.GetComponent<BossScript>().HealthTrick();
            GetComponent<BoxCollider2D>().enabled = false; 
        }
    }
}
