using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGameTrigger : MonoBehaviour
{
    private Vector2 oldMin;
    private Vector2 oldMax;
    public Vector2 newMinMax;

    private FollowPlayer cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<FollowPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            oldMin = cam.min;
            oldMax = cam.max;
            cam.min = newMinMax;
            cam.max = newMinMax;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Player")){
            cam.min = oldMin;
            cam.max = oldMax;
        }
    }
}
