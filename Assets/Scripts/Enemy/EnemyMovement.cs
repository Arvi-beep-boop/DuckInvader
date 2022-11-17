using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 direction = new Vector3(-1.0f, 0.0f, 0.0f);
    public float speed = 4.0f;
    public float health = 3.0f;
    public Animator animator;
    public float HitAnimTime = 0.8f;
    float HitToIdleTimer;


    public GameObject enemyProjectile;
    public float shootCooldown = 2.0f;
    float shootCooldownTime;
    float shootAnimTime = 0.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            animator.SetBool("IsBatHit", true);
            health -= 1.0f;
            if (health <= 0.0f)
            {
                Destroy(gameObject);
            }
            HitToIdleTimer = HitAnimTime;
        }
 
    }

    void Start()
    {
        shootCooldownTime = shootCooldown;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (animator.GetBool("IsBatHit") == true)
        { 
            HitToIdleTimer -= Time.deltaTime;
            if (HitToIdleTimer <= 0.0f)
            {
                animator.SetBool("IsBatHit", false);
            }

        }
        if (shootCooldownTime <= 0.0f)
        {
            animator.SetBool("IsAttacking", true);
            GameObject.Instantiate(enemyProjectile, transform.position, transform.rotation);
            shootAnimTime = 0.5f;
            shootCooldownTime = shootCooldown;
        }
        shootCooldownTime -= Time.deltaTime;

      if (shootAnimTime <= 0.0f)
        {
            animator.SetBool("IsAttacking", false);
        }
        shootAnimTime -= Time.deltaTime;

    }
}
