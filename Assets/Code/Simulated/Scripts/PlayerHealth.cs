using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    [SerializeField] Image _healthBar;
    [SerializeField] TextMeshProUGUI _lifeText;

    [HideInInspector] public int currentHealth;

    public bool getDamage = false;

    private void OnValidate()
    {
        if(getDamage) { 
            GetDamage(25); 
            getDamage = false; }
    }

    private void Start()
    {
        currentHealth = _maxHealth;
        _lifeText.text = currentHealth.ToString() + "%";
        _healthBar.fillAmount = (float)currentHealth/100;
    }
    public void GetDamage(int damage)
    {        
        DOTween.To(() => currentHealth, x => currentHealth = x, currentHealth-damage, 1f)
            .SetEase(Ease.Linear)
            .OnUpdate(UpdateHealthBar);
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = (float)currentHealth / 100f;
        _lifeText.text = currentHealth.ToString() + "%";
    }
}
