using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private AudioSource pewPew;
    public GameObject ammo;
    float timer;
    public Vector3 shootPlaceOffset;

    void Start()
    {
        pewPew = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        
        
        
        float shoot = Input.GetAxisRaw("Jump");
        if (shoot > 0 && timer <= 0.0f)
        {
            pewPew.Play();
            GameObject.Instantiate(ammo, transform.position + shootPlaceOffset, transform.rotation);
            timer = GetComponent<PlayerStatistics>().shootingCooldown;
        }
       timer -= Time.deltaTime;
    }
}
