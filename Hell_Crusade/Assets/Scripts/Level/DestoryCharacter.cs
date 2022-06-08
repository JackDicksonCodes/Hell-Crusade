using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCharacter : MonoBehaviour
{

    void Awake()
    {
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("PlayerHUD"));
        Destroy(GameObject.Find("PlayerHUDV1.3"));

    }
}
