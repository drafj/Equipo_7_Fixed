using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorToolKit : MonoBehaviour
{

    void Start()
    {
        GameManager.instance.agarrarToolKit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Dispensador_Trigger")
        {
            GameManager.instance.agarrarToolKit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Dispensador_Trigger")
        {
            GameManager.instance.agarrarToolKit = false;
            if (GameManager.instance.player.transform.childCount >= 1)
                GameManager.instance.bagReady = true;
            else
                GameManager.instance.bagReady = false;
        }
    }

    void Update()
    {
        
    }
}
