using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public float speed = 6.0f;
    public float health = 10.0f;
    public float shield = 0.0f;
    public float shootingCooldown = 1.0f;

    public HealthBar healthBar;


    public List<PowerUpBase> PowerUps = new List<PowerUpBase>();

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(health);

    }

    // Update is called once per frame
    void Update()
    {
        //apply modifiers
        for (int i = PowerUps.Count - 1; i >= 0; i--)
        {
            PowerUpBase powerUp = PowerUps[i];
            if (powerUp.AdvanceCooldown())
            {
                powerUp.OnRevert(this);
                Destroy(powerUp.gameObject);
                PowerUps.Remove(powerUp);
            }
        }
        healthBar.SetHealth(health);
    }
}
