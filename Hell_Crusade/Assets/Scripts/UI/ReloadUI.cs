using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReloadUI : MonoBehaviour
{
    public TextMeshProUGUI reloadTimerUI;

    private float timer;




    // Update is called once per frame
    void Update()
    {
        if (timer > 0){
            timer -= Time.deltaTime;
            reloadTimerUI = timer.ToString();
        }
    }

    void setTimer(float time){
        timer = time;
    }
}
