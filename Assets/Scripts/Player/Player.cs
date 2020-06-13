using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    public ListaDePosiciones mList;
    public AudioSource dead;
    public GameObject blue;
    public GameObject green;
    public GameObject red;

    void Start()
    {
        
    }

    void Update()
    {
        PesosToolKits();
        ToolKitPicker();
        DesequiparMochila();
    }

    void HurtAndDie()
    {
        if (GameManager.instance.hP <= 0)
        {
            GameManager.instance.inGame = true;
            dead.Play();
            //Destroy(gameObject);
        }
    }

    void PesosToolKits()
    {
        if (GameManager.instance.activadorToolKits[2] && !GameManager.instance.activadorToolKits[1] && !GameManager.instance.activadorToolKits[0])
        {
            GetComponent<Moviment>().speed = 23;
        }
        if (!GameManager.instance.activadorToolKits[2] && GameManager.instance.activadorToolKits[1] && !GameManager.instance.activadorToolKits[0])
        {
            GetComponent<Moviment>().speed = 29;
        }
        if (!GameManager.instance.activadorToolKits[2] && !GameManager.instance.activadorToolKits[1] && GameManager.instance.activadorToolKits[0])
        {
            GetComponent<Moviment>().speed = 34;
        }
        if (GameManager.instance.activadorToolKits[2] && GameManager.instance.activadorToolKits[1] && GameManager.instance.activadorToolKits[0])
        {
            GetComponent<Moviment>().speed = 6;
        }
        if (!GameManager.instance.activadorToolKits[2] && GameManager.instance.activadorToolKits[1] && GameManager.instance.activadorToolKits[0])
        {
            GetComponent<Moviment>().speed = 23;
        }
        if (GameManager.instance.activadorToolKits[2] && !GameManager.instance.activadorToolKits[1] && GameManager.instance.activadorToolKits[0])
        {
            GetComponent<Moviment>().speed = 17;
        }
        if (GameManager.instance.activadorToolKits[2] && GameManager.instance.activadorToolKits[1] && !GameManager.instance.activadorToolKits[0])
        {
            GetComponent<Moviment>().speed = 12;
        }
        if (!GameManager.instance.activadorToolKits[2] && !GameManager.instance.activadorToolKits[1] && !GameManager.instance.activadorToolKits[0] && GameManager.instance.enReparando)
        {
            GetComponent<Moviment>().speed = 40;
        }
        if (!GameManager.instance.enReparando)
        {
            GetComponent<Moviment>().speed = 0;
        }
    }

    void ToolKitPicker()
    {
        if (GameManager.instance.agarrarToolKit == true && Input.GetKeyDown(KeyCode.Alpha1) && !GameManager.instance.activadorToolKits[0] && GameManager.instance.bagReady && !GameManager.instance.armaSacada)
        {
            blue = Instantiate(GameManager.instance.toolKitBlue, transform);
            blue.GetComponent<Rigidbody2D>().simulated = false;
            blue.GetComponent<Toolkit>().myColor = ToolKitColor.Blue;
            blue.transform.localPosition = GameManager.instance.PosicionesToolKits[(int)mList];
            ++mList;
            GameManager.instance.activadorToolKits[0] = true;
        }

        if (GameManager.instance.agarrarToolKit == true && Input.GetKeyDown(KeyCode.Alpha2) && !GameManager.instance.activadorToolKits[1] && GameManager.instance.bagReady && !GameManager.instance.armaSacada)
        {
            green = Instantiate(GameManager.instance.toolKitGreen, transform);
            green.GetComponent<Rigidbody2D>().simulated = false;
            green.GetComponent<Toolkit>().myColor = ToolKitColor.Green;
            green.transform.localPosition = GameManager.instance.PosicionesToolKits[(int)mList];
            ++mList;
            GameManager.instance.activadorToolKits[1] = true;
        }

        if (GameManager.instance.agarrarToolKit == true && Input.GetKeyDown(KeyCode.Alpha3) && !GameManager.instance.activadorToolKits[2] && GameManager.instance.bagReady && !GameManager.instance.armaSacada)
        {
            red = Instantiate(GameManager.instance.toolKitRed, transform);
            red.GetComponent<Rigidbody2D>().simulated = false;
            red.GetComponent<Toolkit>().myColor = ToolKitColor.Red;
            red.transform.localPosition = GameManager.instance.PosicionesToolKits[(int)mList];
            ++mList;
            GameManager.instance.activadorToolKits[2] = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.agarrarToolKit && transform.childCount >= 5 && GameManager.instance.enReparando)
        {
            GameManager.instance.bagReady = true;
            mList = 0;
            if (blue != null)
            {
                GameManager.instance.activadorToolKits[0] = false;
            }
            if (green != null)
            {
                GameManager.instance.activadorToolKits[1] = false;
            }
            if (red != null)
            {
                GameManager.instance.activadorToolKits[2] = false;
            }

            if (transform.childCount == 7)
            {
                Destroy(transform.GetChild(4).gameObject);
                Destroy(transform.GetChild(5).gameObject);
                Destroy(transform.GetChild(6).gameObject);
            }
            else if (transform.childCount == 6)
            {
                Destroy(transform.GetChild(4).gameObject);
                Destroy(transform.GetChild(5).gameObject);
            }
            else if (transform.childCount == 5)
            {
                Destroy(transform.GetChild(4).gameObject);
            }

        }
    }

    void DesequiparMochila()
    {
        if (Input.GetKeyDown(KeyCode.E) && transform.childCount >= 3 && !GameManager.instance.agarrarToolKit && GameManager.instance.enReparando)
        {
            GameManager.instance.bagReady = false;
            if (transform.childCount == 5)
            {
                transform.GetChild(4).gameObject.GetComponent<Rigidbody2D>().simulated = true;
                GameObject go = new GameObject();
                go.AddComponent<ToolKitPicker>();
                transform.GetChild(4).parent = go.transform;
                --mList;
            }

            if (transform.childCount == 6)
            {
                transform.GetChild(4).gameObject.GetComponent<Rigidbody2D>().simulated = true;
                transform.GetChild(5).gameObject.GetComponent<Rigidbody2D>().simulated = true;
                GameObject go = new GameObject();
                go.AddComponent<ToolKitPicker>();
                transform.GetChild(4).parent = go.transform;
                transform.GetChild(4).parent = go.transform;
                mList -= 2;
            }

            if (transform.childCount == 7)
            {
                transform.GetChild(4).gameObject.GetComponent<Rigidbody2D>().simulated = true;
                transform.GetChild(5).gameObject.GetComponent<Rigidbody2D>().simulated = true;
                transform.GetChild(6).gameObject.GetComponent<Rigidbody2D>().simulated = true;
                GameObject go = new GameObject();
                go.AddComponent<ToolKitPicker>();
                transform.GetChild(4).parent = go.transform;
                transform.GetChild(4).parent = go.transform;
                transform.GetChild(4).parent = go.transform;
                mList -= 3;
            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            GameManager.instance.hP -= 5;
            HurtAndDie();
        }
        if (collision.gameObject.GetComponent<enemigo>())
        {
            GameManager.instance.hP -= 1;
            HurtAndDie();
        }
        if (collision.gameObject.GetComponent<eminigo2>())
        {
            GameManager.instance.hP -= 3;
            HurtAndDie();
        }
    }
}

public enum ListaDePosiciones
{
    uno,
    dos,
    tres,
    cuatro
}