using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;
    public GameObject fireIcon;

    void Update(){
        if (playerHealth.onFire == true){
            fireIcon.SetActive(true);
        } else {
            fireIcon.SetActive(false);
        }
    }

    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

}
