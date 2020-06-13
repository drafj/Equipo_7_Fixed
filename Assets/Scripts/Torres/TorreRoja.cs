using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TorreRoja : MonoBehaviour
{
  // public Text textoReparacion;
   float tiempoDeEspera = 10;
   bool sePuedeReparar = true;
   public GameObject torreAzulReparada;
   bool  reparando = true;

    void Start()
    {
        
    }
    void Update()
    {
        if (GameManager.instance.activadorToolKits[2]  && sePuedeReparar == true )
        {
            if (reparando == false )
            {
                tiempoDeEspera -= Time.deltaTime;
                GameManager.instance.tiempoDeReparacion.text = "Repair " + tiempoDeEspera.ToString("f0");
                GameManager.instance.enReparando =false;
            }
        }
        if (tiempoDeEspera <= 0)
        {
            GameManager.instance.reparandoAnim = false;
            GameObject emty;
            emty = Instantiate(torreAzulReparada,transform.position ,Quaternion.identity);
            GameManager.instance.enReparando =true;
            GameManager.instance.torreRojaReparada += 1;
            reparando = false;
            tiempoDeEspera = 10;
            GameManager.instance.hP += 1;
            sePuedeReparar = false;
            GameManager.instance.tiempoDeReparacion.text = "";
            Destroy(this.gameObject);

        }
    }
  
 void OnTriggerStay2D(Collider2D other)
   {
       if (other.gameObject.GetComponent<Player>() && GameManager.instance.activadorToolKits[2] && Input.GetKeyDown(KeyCode.F) && !GameManager.instance.armaSacada)
        {
            reparando = false;
            GameManager.instance.reparandoAnim = true;
        }
    }
}
