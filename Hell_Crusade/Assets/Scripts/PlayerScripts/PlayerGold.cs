using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    private int playerGold;
    // Start is called before the first frame update
    void Start()
    {
        playerGold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addOrSubtractGold(int amount){
        playerGold += amount;
        Debug.Log(playerGold);
    }
}
