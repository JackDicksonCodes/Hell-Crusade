using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCount : MonoBehaviour
{
    public TextMeshProUGUI ammoUI;
    private int currentBullets;
    private bool isHidden;

    void Start(){
        currentBullets = 30;
        isHidden = false;
    }

    void Update(){
        if (isHidden == false){
        ammoUI.text = currentBullets.ToString();
        } else {
            ammoUI.text = "";
        }
    }

    public void currentBulletCount(int bulletCount){
        currentBullets = bulletCount;
        // ammoUI.text = currentBullets.ToString();
    }

    public void toggleHideUI(){
        isHidden = !isHidden;
    }
}
