using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlinkingText : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (timer < blinkCooldown)
        {
            Color color = GetComponent<Text>().color;
            color.a = Mathf.Abs(Mathf.Sin(timer));
            timer += Time.deltaTime;
            GetComponent<Text>().color = color;
        }
    }
}
