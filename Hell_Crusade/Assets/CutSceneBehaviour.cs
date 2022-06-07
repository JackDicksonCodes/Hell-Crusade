using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CutSceneBehaviour : MonoBehaviour
{
    private Camera cam;
    public GameObject secreDoor;
    public GameObject pitfall;
    private GameObject boss;
    private GameObject player;
    public Transform door1Spawn;
    public Transform door2Spawn;
    public GameObject door;
    private bool rdyForPhase1;
    private bool rdyForPhase2;
    private bool phase2Start;
    private bool endPhase;

    
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
        if(boss.GetComponent<BossScript>().health == 4 && rdyForPhase1){
            PhaseOneStart();
        }
        else if(boss.GetComponent<BossScript>().health == 0 && rdyForPhase2){
            PhaseTwoTrigger();
        }
        else if(boss.GetComponent<BossScript>().health == 4 && phase2Start){
            PhaseTwoStart();
        }
        else if(boss.GetComponent<BossScript>().health == 0 && endPhase){
            end();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            GetComponent<BoxCollider2D>().enabled = false; 
            other.gameObject.GetComponent<PlayerMovement>().canMove = false;
            other.gameObject.GetComponent<PlayerShooting>().canShoot = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            rdyForPhase1 = true;
            
            StartCoroutine(DoorSealedSequence());
        }

    }

    private void PhaseTwoTrigger(){
        player.GetComponent<PlayerMovement>().canMove = false;
        player.GetComponent<PlayerShooting>().canShoot = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        cam.GetComponent<FollowPlayer>().changeFollow(boss);
        boss.GetComponent<BossScript>().HealthTrick();
        rdyForPhase2 = false;
        phase2Start = true;
    }

    IEnumerator DoorSealedSequence(){
        int i = 0;
        while(i < 2){
            yield return new WaitForSeconds(1f);
            if(i == 0)
            {
                GameObject door1 = Instantiate(door, door1Spawn.position, Quaternion.identity);
                i++;
            }
            else
            {
                GameObject door2 = Instantiate(door, door2Spawn.position, Quaternion.identity);
                cam.GetComponent<FollowPlayer>().changeFollow(boss);
                boss.GetComponent<BossScript>().HealthTrick();
                i++;
            }

        }

    }

    private void PhaseOneStart()
    {
        cam.GetComponent<FollowPlayer>().changeFollow(player);
        boss.GetComponent<BossPhase1Behaviour>().StartPhase1();
        player.GetComponent<PlayerMovement>().canMove = true;
        player.GetComponent<PlayerShooting>().canShoot = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent< Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        rdyForPhase1 = false;
        rdyForPhase2 = true;
    }

    private void PhaseTwoStart(){
        cam.GetComponent<FollowPlayer>().changeFollow(player);
        player.GetComponent<PlayerMovement>().canMove = true;
        player.GetComponent<PlayerShooting>().canShoot = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent< Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        phase2Start = false;
        endPhase = true;
    }

    private void end(){
        cam.GetComponent<FollowPlayer>().changeFollow(boss);
        StartCoroutine(pitfallSequence());
        
    }

    IEnumerator pitfallSequence(){
        int i = 0;
        while(i < 2){
            yield return new WaitForSeconds(2f);
            if(i == 0){
                pitfall.GetComponent<TilemapCollider2D>().enabled = false;
                pitfall.GetComponent<TilemapRenderer>().enabled = false;
                i ++;
            }
            else{
                cam.GetComponent<FollowPlayer>().changeFollow(secreDoor);
                StartCoroutine(SecretDoorOpen());
                i ++;
            }
        }
    }

    IEnumerator SecretDoorOpen(){
        int i = 0;
        while(i < 2){
            yield return new WaitForSeconds(2f);
            if( i == 0){
                secreDoor.GetComponent<TilemapRenderer>().enabled = true;
                i ++;
            }
            else{
                cam.GetComponent<FollowPlayer>().changeFollow(player);
                i ++;
            }
        }
    }

    
}
