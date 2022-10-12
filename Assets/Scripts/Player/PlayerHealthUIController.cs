using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUIController : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private PlayerController _player;
    [SerializeField] private int health;
    [SerializeField] private int MAX_HEALTH;

    public void UpdateHealthBar()
    {
        _healthBar.fillAmount = _player.CurrentHealth / MAX_HEALTH;
    }
}