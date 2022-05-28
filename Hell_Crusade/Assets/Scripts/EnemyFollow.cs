using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speed;

    private Transform playerPosition;


    // void Awake(){
    //     playerPosition = GameObject.FindGameObjectWithTag("Player").Transform;
    //     }

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Vector2.Distance(transform.position, playerPosition.position) > 0.25f)
        // transform.position = Vector2.MoveTowards(transform, playerPosition, speed * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed *Time.deltaTime);
    }
}
