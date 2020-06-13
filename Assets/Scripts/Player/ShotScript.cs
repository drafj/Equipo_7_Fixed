using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    int ammo = 1;
    public GameObject ammoB;
    public AudioSource noAmmo;
    public AudioSource reLoad;
    public AudioSource equipGun;
    bool sacandoArma = false;

    void Update()
    {
        Shot();

        GameManager.instance.armaSacada = sacandoArma;
        GameManager.instance.player.GetComponent<Moviment>().anim.SetBool("Pj_Idle_Arma", sacandoArma);
    }
    void Shot()
    {
        if(Input.GetKeyDown(KeyCode.Q) && sacandoArma == false && GameManager.instance.player.GetComponent<Moviment>().idle && !GameManager.instance.activadorToolKits[0] && !GameManager.instance.activadorToolKits[1] && !GameManager.instance.activadorToolKits[2])
        {
            StartCoroutine("Equipar");
            equipGun.Play();
        }
        else if(Input.GetKeyDown(KeyCode.Q) && sacandoArma == true && GameManager.instance.player.GetComponent<Moviment>().idle && !GameManager.instance.activadorToolKits[0] && !GameManager.instance.activadorToolKits[1] && !GameManager.instance.activadorToolKits[2])
        {
            sacandoArma = false;
            equipGun.Play();
        }

        if (sacandoArma == true)
        {
            if (Input.GetMouseButtonDown(0) && ammo >= 1)
            {
                Instantiate(ammoB, transform.position + (Vector3.right * 0.5f), transform.rotation);
                ammo--;
            }

            if (Input.GetMouseButtonDown(0) && ammo == 0)
            {
                noAmmo.Play();
            }

            if (Input.GetKey(KeyCode.R) && ammo == 0)
            {
                reLoad.Play();
                ammo++;
            }
        }
    }

    IEnumerator Equipar()
    {
        GameManager.instance.tranEquiparArma = true;

        yield return new WaitForSeconds(0.7f);

        sacandoArma = true;

        GameManager.instance.tranEquiparArma = false;
    }
}
