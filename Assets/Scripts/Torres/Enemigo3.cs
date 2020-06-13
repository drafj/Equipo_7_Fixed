using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    bool disparo = true;
    public int life = 15;
    public GameObject balaIntance;
    public Vector3 direccion;
    public bool idle;
    public bool atack;
    Animator anim;
    public AudioSource audioDisparo;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine("Attack");
    }

    void Update()
    {
        anim.SetBool("Enemigo_3_Atack", atack);
        anim.SetBool("Enemigo_3_Idle", idle);
        Muerte();
        Girar();
        GameObject enemySerca = null;
        float enemyDistance = 10;
        foreach (var enemy in FindObjectsOfType<Player>())
        {
            float temporalDistan = (enemy.transform.position - transform.position).magnitude;
            if (temporalDistan < enemyDistance)
            {
                enemyDistance = temporalDistan;
                enemySerca = enemy.gameObject;
            }
        }
        if (enemySerca != null && GameManager.instance.inGame == false && GameManager.instance.pause == false)
        {
            direccion = Vector3.Normalize(enemySerca.transform.position - transform.position).normalized;
            disparo = false;
            atack = true;
            idle = false;
        }
        else
        {
            atack = false;
            idle = true;
            disparo = true;
        }
    }
  
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.tag == "BulletPlayer")
        {
         life -= 5;
        }
    }
    void Muerte ()
    {
        if (life == 0)
        {
            Destroy(gameObject);
        }
    }
    void Girar()
    {
        if (GameManager.instance.pause == false)
        {
            if (GameManager.instance.inGame == false)
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
    public IEnumerator  Attack()
    {
        while (true)
        {
            if (disparo == false)
            {
               GameObject bulletInstance = Instantiate(balaIntance,transform.position+(Vector3.up*0.5f),Quaternion.identity);
               bulletInstance.GetComponent<BalaEnemiga>().direccion = direccion;
               audioDisparo.Play();
            }
      
         yield return new WaitForSeconds(2f);
            
        }
    }
}
