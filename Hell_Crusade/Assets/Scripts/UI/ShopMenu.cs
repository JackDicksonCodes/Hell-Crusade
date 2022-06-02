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

    //Health Upgrades
    private PlayerHealth playerHealth;
    private int healthLVL = 1;
    public TextMeshProUGUI displayedHealthLVL;
    public TextMeshProUGUI displayedHealthUpgradeCost;
    private int healthUpgradeCost = 25;

    //Weapon Upgrades
    private PlayerShooting playerShooting;
    private int magazineCapLVL = 1;
    public TextMeshProUGUI displayMagazineLVL;
    public TextMeshProUGUI displayedMagazineCapacityCost;
    private int magazineCapacityUpgradeCost = 25;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerGold = player.GetComponent<PlayerGold>();
        playerHealth = player.GetComponent<PlayerHealth>();
        displayedHealthUpgradeCost.text = healthUpgradeCost.ToString();
        playerShooting = player.GetComponent<PlayerShooting>();
        displayedMagazineCapacityCost.text = magazineCapacityUpgradeCost.ToString();
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

    public void purchaseHealthUpgrade(){
        if (playerGold.getGold() >= healthUpgradeCost){
            playerHealth.increaseMaxHealth(5);
            healthLVL += 1;
            displayedHealthLVL.text = "Level: " + healthLVL;
            playerGold.addOrSubtractGold(-healthUpgradeCost);
        } else {
            Debug.Log("Not enough gold");
        }
    }

    public void purchaseMagazineUpgrade(){
        if (playerGold.getGold() >= magazineCapacityUpgradeCost){
            playerShooting.increaseMagazineCapacity();
            magazineCapLVL += 1;
            displayMagazineLVL.text = "Level: " + magazineCapLVL;
            playerGold.addOrSubtractGold(-magazineCapacityUpgradeCost);
        } else {
            Debug.Log("Not enough gold");
        }

    }
}
