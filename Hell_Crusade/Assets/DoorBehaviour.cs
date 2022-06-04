using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public List<GameObject> conditionals;
    


   
    public void removeEnemy(GameObject enemy){
        conditionals.Remove(enemy);
        if(conditionals.Count == 0){
            Destroy(gameObject);
        }
        
    }
}
