using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreNueva : MonoBehaviour
{
    float tiempo = 60;
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
            GameManager.instance.torreAzulReparada -= 1;
        }
    }
}
