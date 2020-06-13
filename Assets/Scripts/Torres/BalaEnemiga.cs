using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : MonoBehaviour
{
    public Vector3 direccion;
    float speed = 10;
    void Start()
    {
        
    }
    void Update()
    {
        if(GameManager.instance.pause == false)
        transform.position += direccion * speed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
    }
}
