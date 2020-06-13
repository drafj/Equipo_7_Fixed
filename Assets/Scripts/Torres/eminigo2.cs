using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eminigo2 : MonoBehaviour
{
    public int life = 10;
    public bool idle;
    public bool atack;
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        anim.SetBool("Enemigo_2_Atack", atack);
        anim.SetBool("Enemigo_2_Idle", idle);
         muerte();
         Girar();
         GameObject playerSerca  = null;
         float enemyDistance = 10;
        foreach (var player in FindObjectsOfType<Player>())
        {
            float temporalDistan = (player.transform.position - transform.position ).magnitude;
                if  (temporalDistan <= enemyDistance)
                {
                    enemyDistance = temporalDistan; 
                    playerSerca = player.gameObject;
                }
        }
        if (playerSerca != null && GameManager.instance.inGame == false && GameManager.instance.pause == false)
        {
            atack = true;
            idle = false;
            enemyDistance = (playerSerca.transform.position - transform.position).magnitude;
            Vector3 direccion = (playerSerca.transform.position - transform.position).normalized;
            transform.position += (direccion * 2f * Time.deltaTime);
        }
        else if (playerSerca == null)
        {
            atack = false;
            idle = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "BulletPlayer")
        {
            life -= 5;
        }
    }
    void muerte()
    {
        if (life == 0)
        {
            Destroy(gameObject);
        }
    }
     void Girar()
    {
        if (GameManager.instance.inGame == false || GameManager.instance.pause == false)
        {
            if (GameManager.instance.player.transform.position.x < transform.position.x)
            { 
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (GameManager.instance.player.transform.position.x > transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        
    }

}
