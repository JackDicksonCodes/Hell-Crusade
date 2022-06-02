using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemyScript : MonoBehaviour
{
    public int health = 2;
    public int goldDrop;
    private EnemyExplode enemyExplode;

    //accessing player then finding the goldscript
    private GameObject player;
    private PlayerGold playerGold;
    public AudioSource enemySounds;
    public AudioClip enemyScream;
    private bool isDead = false;

    void Start(){
        enemyExplode = gameObject.GetComponent<EnemyExplode>();
        player = GameObject.Find("Player");
        playerGold = player.GetComponent<PlayerGold>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            isDead = true;
            enemyExplode.spawnExplosion();
            playerGold.addOrSubtractGold(goldDrop);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
            health -= 1;
            FindObjectOfType<ExplosionEnemyDetection>().ChangeToCombat();
            enemySounds.PlayOneShot(enemyScream);
        }
    }
    public int getHealth(){
        return health;
    }

    public bool getIsDead(){
        return isDead;
    }
}
