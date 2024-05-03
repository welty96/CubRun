using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public player player;
    Image healthBar;
    public float maxHealth = 100;
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        healthBar= GetComponent<Image>();
        maxHealth = player.HP;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = player.HP / maxHealth;
    }
}
