using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float length, startposx, startposy;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startposx = transform.position.x;
        startposy = transform.position.y;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (Camera.main.transform.position.x * (1 - parallaxEffect));
        float distancex = (Camera.main.transform.position.x * parallaxEffect);
        float distancey = (Camera.main.transform.position.y * parallaxEffect);

        transform.position = new Vector3(startposx + distancex, startposy + distancey, transform.position.z);

        if (temp > startposx + length)
            startposx += length;
        else if (temp < startposx - length)
            startposx -= length;
    }
}
