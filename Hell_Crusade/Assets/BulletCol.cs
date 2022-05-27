using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCol : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
            col.gameObject.SendMessage("takeHit", 1);
        }
        else if(col.gameObject.tag.Equals("Wall")){
            Destroy(gameObject);
        }
        
    }
}
