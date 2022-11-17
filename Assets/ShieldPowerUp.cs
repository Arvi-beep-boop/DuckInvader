using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldPowerUp : PowerUpBase
{
    public float shieldDuration = 4.0f;

    public HealthBar healthBar;
    public Image shield;
    void Start()
    {
        cooldown = 5.0f;
    }

    public override void OnApply(PlayerStatistics stats)
    {
        stats.shield += shieldDuration;
        healthBar.fill.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        healthBar.SetHealth(10.0f);
        shield.gameObject.SetActive(true);
        
    }
    public override void OnRevert(PlayerStatistics stats)
    {
        //stats.shield = Mathf.Max(stats.shield - shieldDuration, 0.0f);

        stats.shield -= shieldDuration;

        if (stats.shield <= 0.0f)
        {
            stats.shield = 0.0f;
            healthBar.fill.color = Color.red;
            shield.gameObject.SetActive(false);

        }
    }

}
