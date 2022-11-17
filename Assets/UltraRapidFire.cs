using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltraRapidFire : PowerUpBase
{
    // editable property
    public Image urf;
    public float shootingModifier = 0.5f;

    bool ignore = false;

    private void Start()
    {
        cooldown = 15.0f;
    }

    public override void OnApply(PlayerStatistics stats)
    {
        if(stats.shootingCooldown * shootingModifier <= 0.0f)
        {
            ignore = true;
            return;
        }

        stats.shootingCooldown *= shootingModifier;
        urf.gameObject.SetActive(true);
    }

    public override void OnRevert(PlayerStatistics stats)
    {
        if (!ignore)
        {
            stats.shootingCooldown /= shootingModifier;
            urf.gameObject.SetActive(false);

        }

    }
}
