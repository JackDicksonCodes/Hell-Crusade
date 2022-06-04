using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   public Transform player;
   public float distance;
   private Vector3 cam;
   public Vector2 max;
   public Vector2 min;
   public float smoothing;
    
   void LateUpdate(){

      cam = new Vector3(player.position.x, player.position.y, player.position.z - distance);
      cam.x = Mathf.Clamp(cam.x, min.x, max.x);
      cam.y = Mathf.Clamp(cam.y, min.y, max.y);
      transform.position = Vector3.Lerp(transform.position, cam, smoothing);

   }

   


}
