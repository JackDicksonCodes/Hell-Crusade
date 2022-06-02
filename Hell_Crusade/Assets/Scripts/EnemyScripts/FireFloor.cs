using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFloor : MonoBehaviour
{
    private float duration = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(duration > 0){
            duration -= Time.deltaTime;
        }
        else{
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player")){
           col.gameObject.GetComponent<PlayerHealth>().onFire = true;
           col.gameObject.GetComponent<PlayerHealth>().fireDuration = 5f;
        }
    }
}
