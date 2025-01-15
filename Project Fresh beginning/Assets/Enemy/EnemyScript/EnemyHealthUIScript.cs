using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUIScript
{
    public Slider sliderUI;
    public Image FillBackGround;
    public Text HealthText;

    public void UpdateHealth(float health)
    {
        sliderUI.value = health;
        HealthText.text = $"{health}/100";
    }
    
}
