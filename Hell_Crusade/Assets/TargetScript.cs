using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    private int health = 1;
    public GameObject door;
    public AudioSource enemySounds;
    public AudioClip enemyScream;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
            health -= 1;
            AudioSource.PlayClipAtPoint(enemyScream, transform.position);
            if(health <= 0){
                Destroy(gameObject);
            }
        }
        
    }

     private void OnDestroy() 
    {
        if(door){
            door.GetComponent<DoorBehaviour>().removeEnemy(gameObject);
        }
    }
}
