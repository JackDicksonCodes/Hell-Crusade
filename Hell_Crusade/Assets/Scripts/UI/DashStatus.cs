using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashStatus : MonoBehaviour
{
    public TextMeshProUGUI dashStatusUI;
    string cooldown;

    public void dashIsReady(){
        dashStatusUI.text = "Dash: Ready";
    }

    public void dashInUse(){
        dashStatusUI.text = "DASHING";
    }

    public void dashOnCooldown(float time){
        cooldown = time.ToString("0.00");
        dashStatusUI.text = $"Dash Cooldown: {cooldown}";
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
