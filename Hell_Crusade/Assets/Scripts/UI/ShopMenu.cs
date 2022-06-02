using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public static bool isOpen = false;
    public GameObject shopMenu;
    private GameObject player;
    private PlayerGold playerGold;
    private PlayerHealth playerHealth;
    

    private int healthUpgradeCost = 50;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerGold = player.GetComponent<PlayerGold>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            if (isOpen == false){
                openMenu();
            } else {
                closeMenu();
            }
        }
    }

    void openMenu(){
        shopMenu.SetActive(true);
        isOpen = true;
    }

    void closeMenu(){
        shopMenu.SetActive(false);
        isOpen = false;
    }

    public void purchaseHealth(){
        if (playerGold.getGold() >= healthUpgradeCost){
            playerHealth.increaseMaxHealth(5);
            playerGold.addOrSubtractGold(-healthUpgradeCost);

        }
    }
}
