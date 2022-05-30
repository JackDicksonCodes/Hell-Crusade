using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReloadUI : MonoBehaviour
{
    public TextMeshProUGUI reloadTimerUI;

    private float timer;

    // void Start(){
        // timer = 2f;
    // }


    // Update is called once per frame
    void Update()
    {
        if (timer > 0){
            timer -= Time.deltaTime;
            reloadTimerUI.text = timer.ToString("0.00");
        }

        if (timer <= 0) {
            reloadTimerUI.text = "";
        }
    }

    public void setTimer(float time){
        timer = time;
    }
}
