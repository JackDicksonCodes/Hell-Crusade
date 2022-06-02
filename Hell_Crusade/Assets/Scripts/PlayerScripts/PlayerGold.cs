using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    private int playerGold;
    public GoldUI goldUI;
    // Start is called before the first frame update
    void Start()
    {
        playerGold = 0;
        goldUI.updateGold(playerGold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addOrSubtractGold(int amount){
        playerGold += amount;
        goldUI.updateGold(playerGold);
    }
    
    public int getGold(){
        return playerGold;
    }
}
