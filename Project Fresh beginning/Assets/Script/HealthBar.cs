using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueText;

    public void UpdateBar(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}