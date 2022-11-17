using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed = 8.0f;
 
    Vector3 direction;
    float top;
    float bottom;
    float left;
    float right;

    void Start()
    {
        transform.rotation *= Quaternion.Euler(0.0f, 0.0f,Random.Range(-2.0f, 2.0f));

        direction = transform.rotation * Vector3.right;
        float HalfSizeVertical = Camera.main.orthographicSize;
        float HalfSizeHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height; // aspect ratio

        Destroy(gameObject, 8.0f);

        left = -HalfSizeHorizontal;
        right = HalfSizeHorizontal;
        top = HalfSizeVertical;
        bottom = -HalfSizeVertical;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            direction = Vector3.Reflect(direction, collision.contacts[0].normal);
            transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
            transform.rotation *= Quaternion.Euler(0.0f, 0.0f, Random.Range(-2.0f, 2.0f));
            speed -= 0.1f * speed;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;
        if (transform.position.x > right || transform.position.x < left)
        {
           // Destroy(gameObject);
        }
        if (transform.position.y > top || transform.position.y < bottom)
        {
           // Destroy(gameObject);
        }
    }
}
