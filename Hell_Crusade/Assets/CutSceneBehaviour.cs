using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneBehaviour : MonoBehaviour
{
    private Camera cam;
    private GameObject boss;
    private GameObject player;
    public Transform door1Spawn;
    public Transform door2Spawn;
    public GameObject door;
    
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
            player.GetComponent<PlayerMovement>().canMove = true;
            player.GetComponent<PlayerShooting>().canShoot = true;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            GetComponent<BoxCollider2D>().enabled = false; 
            other.gameObject.GetComponent<PlayerMovement>().canMove = false;
            other.gameObject.GetComponent<PlayerShooting>().canShoot = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(DoorSealedSequence());
        }
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
}
