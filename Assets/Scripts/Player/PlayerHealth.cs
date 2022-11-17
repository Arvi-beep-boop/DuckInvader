using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            if (GetComponent<PlayerStatistics>().shield > 0.0f)
            {
                GetComponent<PlayerStatistics>().shield -= 1.0f;
            }
            else
            {
                GetComponent<PlayerStatistics>().health -= 1.0f;
            }
        }
    }
    void Start()
    {

    }

    void Update()
    {
        
        if (GetComponent<PlayerStatistics>().health <= 0.0f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("EntryScreen");
        }
    }
}
