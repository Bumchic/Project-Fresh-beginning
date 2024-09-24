using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerStat : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int curentHealth;

    public HealthBar healthBar;
    public UnityEvent OnDeath;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    private void Start()
    {
        curentHealth = maxHealth;
        healthBar.UpdateBar(curentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        curentHealth -= damage;

        if (curentHealth < 0)
        {
            curentHealth = 0;
            OnDeath.Invoke();
        }
        healthBar.UpdateBar(curentHealth, maxHealth);
    }

    public void Heal(int healAmount)
    {
        curentHealth += healAmount;

        if (curentHealth > maxHealth)
        {
            curentHealth = maxHealth;
        }
        healthBar.UpdateBar(curentHealth, maxHealth);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TakeDamage(10); // Nhấn 9 để nhận sát thương
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Heal(10); // Nhấn 0 để hồi máu
        }
    }
}
