using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableCandleDestination : MonoBehaviour
{
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag.Equals("Candle")){
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.gameObject.GetComponent<Rigidbody2D>().isKinematic =true;
            other.gameObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1.2f);
            GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<MovableCandleBehaviour>().active = false;
        }
    }
    
}
