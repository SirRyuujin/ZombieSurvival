using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUIController : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private IntVariable _playerCurrentHealth;
    [SerializeField] private IntVariable _playerMaxHealth;

    public void UpdateHealthBar()
    {
        _healthBar.fillAmount = (float)_playerCurrentHealth.Value / (float)_playerMaxHealth.Value;
    }
}