using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public float speed = 1;
    public bool atack;
    Animator anim;
    public bool direccion = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("Enemigo_1_Atack", atack);
        Patrullaje();
    }
    void Patrullaje()
    {
        if (GameManager.instance.inGame == false && GameManager.instance.pause == false)
        {
            atack = true;

            if (direccion == true)
            {
            transform.position -= transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1,1);
            }
            if (direccion == false)
            {
            transform.position += transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1,1);
            }
        }
        
    }
   void OnTriggerEnter2D(Collider2D other)
    {
       if (other.transform.tag == "tope1")
       {
           direccion = false;
       }
       if (other.transform.tag == "tope2")
       {
           direccion = true;
       }
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BulletPlayer")
        {
            Destroy(this.gameObject);
        }
    }
   
}
