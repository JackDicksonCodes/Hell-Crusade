using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorBehaviour : MonoBehaviour
{
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
       boss = GameObject.Find("TheEyeOfTerror");
    }

    // Update is called once per frame
    void Update()
    {
        if(boss == null){
            Destroy(gameObject);
        }
    }
}
