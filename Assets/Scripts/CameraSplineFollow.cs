using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSplineFollow : MonoBehaviour
{
    public float speed = 1.5f;
    public GameObject spline;
    Spline source;
    float t = 0.0f;
    int countryRoad;
    int countryRoadIndex = 1;
    bool dataCollected = false;
    void Start()
    {
       
        
    }

    void Update()
    {
        if (dataCollected == false)
        {
            source = spline.GetComponent<Spline>();
            countryRoad = source.getSegmentsNum();
            dataCollected = true;
        }
        if (countryRoadIndex <= countryRoad)
        {
            transform.position = source.EvaluateAt(t, countryRoadIndex);

            t += speed * Time.deltaTime;
            if (t > 1.0f)
            {
                t = 0.0f;
                countryRoadIndex += 1;
            }
        }
    }
}
