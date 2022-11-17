using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    Vector3[] points;
    void Start()
    {
        InitPoints();
    }

    // Update is called once per frame
    void OnDrawGizmos()
    {
        InitPoints();

        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i+1]);
        }
        for (int j = 0; j < points.Length - 3; j++)
        { 
            for (float i = 0; i < 1.0f; i += 0.01f)
            {
                Vector3 start = EvaluateCatmullRomSpline(i, points[j], points[j+1], points[j+2], points[j+3]);
                Vector3 end = EvaluateCatmullRomSpline(i + 0.01f, points[j], points[j+1], points[j+2], points[j+3]);
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(start, end);
            }
        }
    }

    Vector3 EvaluateCatmullRomSpline(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 a = 2f * p1;
        Vector3 b = p2 - p0;
        Vector3 c = 2f * p0 - 5f * p1 + 4f * p2 - p3;
        Vector3 d = -p0 + 3f * p1 - 3f * p2 + p3;

        Vector3 res = 0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t));

        return res;
    }

    void InitPoints()
    {
        int count = transform.childCount;
        points = new Vector3[count];

        for (int i = 0; i < count; i++)
        {
            points[i] = transform.GetChild(i).position;
        }
    }
    public Vector3 EvaluateAt(float t, int segment)
    {
        return EvaluateCatmullRomSpline(t, points[segment-1], points[segment], points[segment+1], points[segment+2]);
    }
    public int getSegmentsNum()
    {
        return points.Length - 3;
    }
}

