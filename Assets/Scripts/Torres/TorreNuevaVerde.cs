using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreNuevaVerde : MonoBehaviour
{
    float tiempo = 120;
    public GameObject torre;
    void Start()
    {
    }
    void Update()
    {
        tiempo -= Time.deltaTime;
        print(tiempo);
        GeneraTorreDañada();

    }
    void GeneraTorreDañada()
    {
        if (tiempo <= 0)
        {
            GameObject emty;
            emty = Instantiate(torre,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.instance.torreVerdeReparada -= 1;
        }
    }
}