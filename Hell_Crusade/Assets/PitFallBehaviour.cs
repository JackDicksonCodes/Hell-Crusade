using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFallBehaviour : MonoBehaviour
{
    public Transform entrance;
 
 private void OnTriggerEnter2D(Collider2D other) {
     if(other.gameObject.tag.Equals("Player")){
         PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
         health.ReceiveDamage(2);
         other.gameObject.transform.position = new Vector2(entrance.position.x, entrance.position.y);
     }
 }
}
