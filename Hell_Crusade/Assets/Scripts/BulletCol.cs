using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Wall"))
        {
            Destroy(gameObject);
        }
        if(col.gameObject.tag.Equals("Target")){
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
