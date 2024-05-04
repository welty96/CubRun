using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public player player;
    Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar= GetComponent<Image>();
        player.OnDamage += OnDamage;
    }

    private void OnDamage()
    {
        healthBar.fillAmount = player.Hp / player.maxHp;
    }
}
