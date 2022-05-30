using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private bool isRadarOn {get; set;}
    public Transform radarStart;
    // private Transform radarDir;
    private float radarSpeed = 15f;
    private Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
        isRadarOn = true;
        axis = new Vector3(0,0,1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isRadarOn){
            radarStart.RotateAround(radarStart.position, axis, radarSpeed);
            RaycastHit2D radar = Physics2D.Raycast(radarStart.position, radarStart.up);
            if(radar.collider.tag == "Player"){
                Debug.Log("found you");
            }
            Debug.DrawLine(radarStart.position, radarStart.up, Color.green);
        }
    }
}
