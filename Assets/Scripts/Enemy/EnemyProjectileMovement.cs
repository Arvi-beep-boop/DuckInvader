using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 direction = new Vector3(-1.0f, 0.0f, 0.0f);
    float liveTime = 4.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
        liveTime -= Time.deltaTime;
        if (liveTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
