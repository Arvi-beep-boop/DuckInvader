using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected float cooldown;

    public abstract void OnApply(PlayerStatistics stats);
    public abstract void OnRevert(PlayerStatistics stats);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerStatistics stats = collision.gameObject.GetComponent<PlayerStatistics>();
        if(stats)
        {
            OnApply(stats);
            stats.PowerUps.Add(this);
            gameObject.SetActive(false);
        }    
    }

    public bool AdvanceCooldown()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0.0f)
        {
            return true;
        }

        return false;
    }
}
