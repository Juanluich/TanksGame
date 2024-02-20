using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI lifeText;

    private int currentHealth;

    public bool getDamage = false;

    private void OnValidate()
    {
        if(getDamage) { GetDamage(25); getDamage = false; }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        lifeText.text = currentHealth.ToString() + "%";
        healthBar.fillAmount = (float)currentHealth/100;
    }
    public void GetDamage(int damage)
    {        
        DOTween.To(() => currentHealth, x => currentHealth = x, currentHealth-damage, 1f)
            .SetEase(Ease.Linear)
            .OnUpdate(UpdateHealthBar);
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / 100f;
        lifeText.text = currentHealth.ToString() + "%";
    }
}
