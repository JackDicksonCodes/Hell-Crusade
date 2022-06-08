using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    public Slider slider;
    public BossScript bossScript;

        public void SetHealth(int health)
    {
        slider.value = health;
    }
}
