using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Camera cam;
    Rigidbody2D body;
    Vector2 movement;
    Vector2 mouse;


    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mouse = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKey(KeyCode.LeftShift)){
            speed = 7.0f;
        }
        else{
            speed = 5.0f;
        }

    }
    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * speed * Time.deltaTime);

        Vector2 dir = mouse - body.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
    }
}
