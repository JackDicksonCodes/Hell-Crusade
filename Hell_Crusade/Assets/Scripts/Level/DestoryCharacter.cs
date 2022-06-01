using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCharacter : MonoBehaviour
{

    void Start()
    {
        if (GameObject.Find("Player") != null){
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameObject.Find("PlayerHUD"));
        }

    }
}
