using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCandleBehaviour : MonoBehaviour
{
    private Rigidbody2D body;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag.Equals("Player") && active){
            body.isKinematic = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        body.isKinematic = true;
        body.velocity = Vector2.zero;
    }
}
