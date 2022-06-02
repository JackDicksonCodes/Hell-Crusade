using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemyScript : MonoBehaviour
{
    public int health = 2;
    public int goldDrop;
    private EnemyExplode enemyExplode;
    public PlayerGold playerGold;

    void Start(){
        enemyExplode = gameObject.GetComponent<EnemyExplode>();
        // playerGold =
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0){
            enemyExplode.spawnExplosion();
            Destroy(gameObject);
            playerGold.addOrSubtractGold(goldDrop);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
            health -= 1;
            FindObjectOfType<ExplosionEnemyDetection>().ChangeToCombat();
        }
    }
    public int getHealth(){
        return health;
    }
}
