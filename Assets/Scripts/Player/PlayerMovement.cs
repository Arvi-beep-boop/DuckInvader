using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float top;
    float bottom;
    float left;
    float right;
    void Start()
    {
        float HalfSizeVertical = Camera.main.orthographicSize;
        float HalfSizeHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height; // aspect ratio
        left = -HalfSizeHorizontal;
        right = HalfSizeHorizontal;
        top = HalfSizeVertical;
        bottom = -HalfSizeVertical;
        //transform.position = Camera.main.transform.position;
    }

    void Update()
    {
        float movement_x = Input.GetAxisRaw("Horizontal");
        float movement_y = Input.GetAxisRaw("Vertical");
        Vector3 position = transform.position;
        
        if (transform.position.x > Camera.main.transform.position.x + right  || transform.position.x < Camera.main.transform.position.x + left)
        {
            position.x = Mathf.Clamp(transform.position.x, Camera.main.transform.position.x + left, Camera.main.transform.position.x + right);
            transform.position = position;
        }
        if (transform.position.y > Camera.main.transform.position.y + top || transform.position.y < Camera.main.transform.position.y + bottom)
        {
            position.y = Mathf.Clamp(transform.position.y, Camera.main.transform.position.y + bottom, Camera.main.transform.position.y + top);
            transform.position = position;


        }
        transform.position += new Vector3(movement_x, movement_y, 0).normalized * GetComponent<PlayerStatistics>().speed * Time.deltaTime;

    }
}
