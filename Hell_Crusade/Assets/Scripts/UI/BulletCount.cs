using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCount : MonoBehaviour
{
    public TextMeshProUGUI ammoUI;
    private int currentBullets;

    void Start(){
        currentBullets = 30;
    }

    void Update(){
        ammoUI.text = currentBullets.ToString();
    }

    public void currentBulletCount(int bulletCount){
        currentBullets = bulletCount;
        // ammoUI.text = currentBullets.ToString();
    }
}
