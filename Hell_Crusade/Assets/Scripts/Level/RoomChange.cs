using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public Vector2 cameraChangeMin;
    public Vector2 cameraChangeMax;
    public Vector3 playerChange;
    private FollowPlayer cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<FollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag.Equals("Player")){
            cam.min = cameraChangeMin;
            cam.max = cameraChangeMax;
            other.transform.position += playerChange;
        }
    }

    
}
