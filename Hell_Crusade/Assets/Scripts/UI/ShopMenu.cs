using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public static bool isOpen = false;
    public GameObject shopMenu;
    public TextMeshProUGUI shopMessage;
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
        playerShooting = player.GetComponent<PlayerShooting>();
        displayedHealthUpgradeCost.text = healthUpgradeCost.ToString();
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

    void displayShopMessage(string message){
        shopMessage.text = message;
    }

    public void purchaseHealthUpgrade(){
        if (playerGold.getGold() >= healthUpgradeCost){
            playerHealth.increaseMaxHealth(5);
            healthLVL += 1;
            displayedHealthLVL.text = "Level: " + healthLVL;
            playerGold.addOrSubtractGold(-healthUpgradeCost);
            displayShopMessage("Health upgrade purchased!");
        } else {
            displayShopMessage("Not enough gold!!!");
        }
    }

    public void purchaseMagazineUpgrade(){
        if (playerGold.getGold() >= magazineCapacityUpgradeCost){
            playerShooting.increaseMagazineCapacity();
            magazineCapLVL += 1;
            displayMagazineLVL.text = "Level: " + magazineCapLVL;
            playerGold.addOrSubtractGold(-magazineCapacityUpgradeCost);
            displayShopMessage("Magazine upgrade purchased!");
        } else {
            displayShopMessage("Not enough gold!!!");
        }
    }

    IEnumerator messageDuration(){
        yield return new WaitForSeconds(5); //message will disappear after entered seconds
    }
}
