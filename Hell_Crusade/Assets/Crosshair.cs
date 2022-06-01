using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Awake() 
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursor;
    }
}
