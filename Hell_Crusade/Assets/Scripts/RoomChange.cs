using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public Vector2 cameraChange;
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player")){
            cam.min += cameraChange;
            cam.max += cameraChange;
            other.transform.position += playerChange;
        }
    }
}
