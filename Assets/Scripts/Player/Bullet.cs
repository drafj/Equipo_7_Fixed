using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rgbd;
    string direction;
    // Start is called before the first frame update
    void Start()
    {
        if (Moviment.bulletDirection == false)
        {
            direction = "Derecha";
        }
        else if(Moviment.bulletDirection == true)
        {
            direction = "Izquierda";
        }
            Invoke("DestroyBullet", 1.5f);
        rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

            if (direction == "Derecha")
            {
                transform.position += transform.right * 10 * Time.deltaTime;
            }
            else if (direction == "Izquierda")
            {
                transform.position -= transform.right * 10 * Time.deltaTime;
            }
        
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<enemigo>() || other.GetComponent<eminigo2>() || other.GetComponent<Enemigo3>())
        {
            Destroy(gameObject);
        }

    }
}