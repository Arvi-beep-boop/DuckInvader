using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject canvas;
    public GameObject enemy;
    public GameObject urfPowerUp;
    public GameObject shieldPowerUp;
    public GameObject wall;

    float top;
    float bottom;
    float left;
    float right;

    float enemySpawnCd;
    float shieldSpawnCd;
    float urfSpawnCd;
    float wallSpawnCd;

    void Start()
    {
        float HalfSizeVertical = Camera.main.orthographicSize;
        float HalfSizeHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height; // aspect ratio
        left = -HalfSizeHorizontal;
        right = HalfSizeHorizontal;
        top = HalfSizeVertical;
        bottom = -HalfSizeVertical;

        enemySpawnCd = Random.Range(3.0f, 6.0f);
        shieldSpawnCd = Random.Range(8.0f, 20.0f);
        urfSpawnCd = Random.Range(8.0f, 18.0f);
        wallSpawnCd = Random.Range(10.0f, 15.0f);
    }

    
    void Update()
    {
        //enemy
        enemySpawnCd -= Time.deltaTime;
        if (enemySpawnCd <= 0.0f)
        {
            Vector3 enemyPosition = new Vector3(Camera.main.transform.position.x + right+5.0f, Random.Range(bottom, top), 15.19853f);
            GameObject.Instantiate(enemy, enemyPosition, transform.rotation);
            enemySpawnCd = Random.Range(2.0f, 4.0f);
        }
        //shield
        shieldSpawnCd -= Time.deltaTime;
        if(shieldSpawnCd <= 0.0f)
        {
            shieldSpawnCd = RandomSpawnPowerUp(shieldPowerUp, shieldSpawnCd);
        }
        //urf
        urfSpawnCd -= Time.deltaTime;
        if (urfSpawnCd <= 0.0f)
        {
            urfSpawnCd = RandomSpawnPowerUp(urfPowerUp,urfSpawnCd);
        }
        //wall
        wallSpawnCd -= Time.deltaTime;
        if(wallSpawnCd <= 0.0f)
        {
            wallSpawnCd = RandomSpawnStructure(wall, wallSpawnCd);
        }

        if (PauseMenu.IsGamePaused)
        {
            Debug.Log("Game is Paused");
        }
       
    }
    float RandomSpawnPowerUp(GameObject objectName, float cooldown)
    {
        Vector3 position = new Vector3(Camera.main.transform.position.x + right + 5.0f, Random.Range(bottom, top), 15.19853f);
        cooldown = Random.Range(8.0f, 20.0f);
        GameObject.Instantiate(objectName, position, transform.rotation);
        return cooldown;
    }

    float RandomSpawnStructure(GameObject objectName, float cooldown)
    {
        Vector3 position = new Vector3(Camera.main.transform.position.x + right + 5.0f, Random.Range(bottom, top), 15.19853f);
        Quaternion rotation = new Quaternion(0.0f, 0.0f, Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        GameObject.Instantiate(objectName, position, rotation);
        cooldown = Random.Range(5.0f, 10.0f);

        return cooldown;
    }
}
