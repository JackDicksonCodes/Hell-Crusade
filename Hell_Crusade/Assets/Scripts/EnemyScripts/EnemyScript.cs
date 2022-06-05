using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 2;
    public int goldDrop;

    private GameObject player;
    private PlayerGold playerGold;
    public AudioSource enemySounds;
    public AudioClip enemyScream;
    public GameObject door;
    

    void Start()
    {
        player = GameObject.Find("Player");
        playerGold = player.GetComponent<PlayerGold>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            playerGold.addOrSubtractGold(goldDrop);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
            health -= 1;
            if(FindObjectOfType<MeleeDetection>()){
                FindObjectOfType<MeleeDetection>().ChangeToCombat();
            }
            else if(FindObjectOfType<EnemyDetection>()){
                FindObjectOfType<EnemyDetection>().ChangeToCombat();
            }
            enemySounds.PlayOneShot(enemyScream);
        }
        
    }


    private void OnDestroy() 
    {
        if(door){
            door.GetComponent<DoorBehaviour>().removeEnemy(gameObject);
        }
    }
}
