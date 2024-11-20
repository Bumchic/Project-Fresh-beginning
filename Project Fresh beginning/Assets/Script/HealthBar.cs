using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI valueText;
    public float CurrentHealth;
    public float Cur;
    public void UpdateBar(float currentValue, float maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
    void Awake()
    {
        CurrentHealth = GameManager.gameManager.PlayerHealth.currentHealth;
    }
    void Update()
    {
        if (GameManager.gameManager.PlayerHealth.currentHealth != CurrentHealth)
        {
            UpdateBar(GameManager.gameManager.PlayerHealth.currentHealth, GameManager.gameManager.PlayerHealth.MaxHealth);
            CurrentHealth = GameManager.gameManager.PlayerHealth.currentHealth;
            Debug.Log("Health");
        }
        Cur = GameManager.gameManager.PlayerHealth.currentHealth;
    }
}