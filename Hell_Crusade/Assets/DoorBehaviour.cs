using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public List<GameObject> enemies;
    

    public void removeEnemy(GameObject enemy){
        enemies.Remove(enemy);
        if(enemies.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}
