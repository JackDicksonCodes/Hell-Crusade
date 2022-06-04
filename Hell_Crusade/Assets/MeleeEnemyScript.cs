using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : MonoBehaviour
{
      public int health = 2;
    public int goldDrop;

    private GameObject player;
    private PlayerGold playerGold;
    public AudioSource enemySounds;
    public AudioClip enemyScream;
    public bool isAlive;

    void Start()
    {
        player = GameObject.Find("Player");
        playerGold = player.GetComponent<PlayerGold>();
        isAlive = true;
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
            FindObjectOfType<MeleeDetection>().ChangeToCombat();
            enemySounds.PlayOneShot(enemyScream);
        }
        
    }

    // private void OnDestroy() 
    // {
    //     isAlive = false;
    //     if(FindObjectOfType<DoorBehaviour>()){
    //         FindObjectOfType<DoorBehaviour>().removeEnemy(gameObject);
    //     }
    // }
}
