using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUIScript
{
    public Slider sliderUI;
    public Image FillBackGround;
    public Transform Target;
    public EnemyHealthUIScript(Slider slider, Image FillBackGround, Transform Target)
    {
        sliderUI = slider;
        this.FillBackGround = FillBackGround;
        this.Target = Target;
        
    }
    public void UpdateHealth(float health)
    {
        sliderUI.value = health;
    }
    
}
