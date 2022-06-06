using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaboomBehaviour : MonoBehaviour
{
    private GameObject player;
    private float distance;
    private bool canDoDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        canDoDamage = true;
        StartCoroutine(DurationSequence());
        
    }

    void Update(){
        distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < 2.65 && canDoDamage){
            player.GetComponent<PlayerHealth>().ReceiveDamage(10);
            canDoDamage = false;
        }
    }

    

    IEnumerator DurationSequence(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    
}
