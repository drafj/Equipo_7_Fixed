using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolKitPicker : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            Destroy(gameObject);
        }

        if (GameManager.instance.pickBagReady && Input.GetKeyDown(KeyCode.E) && !GameManager.instance.armaSacada)
        {
            if (transform.childCount == 1)
            {
                transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = false;
                transform.GetChild(0).parent = GameManager.instance.player.transform;
                GameManager.instance.player.transform.GetChild(4).localPosition = GameManager.instance.PosicionesToolKits[(int)GameManager.instance.player.GetComponent<Player>().mList];
                ++GameManager.instance.player.GetComponent<Player>().mList;
            }

            if (transform.childCount == 2)
            {
                transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = false;
                transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = false;
                transform.GetChild(0).parent = GameManager.instance.player.transform;
                transform.GetChild(0).parent = GameManager.instance.player.transform;
                GameManager.instance.player.transform.GetChild(4).localPosition = GameManager.instance.PosicionesToolKits[(int)GameManager.instance.player.GetComponent<Player>().mList];
                ++GameManager.instance.player.GetComponent<Player>().mList;
                GameManager.instance.player.transform.GetChild(5).localPosition = GameManager.instance.PosicionesToolKits[(int)GameManager.instance.player.GetComponent<Player>().mList];
                ++GameManager.instance.player.GetComponent<Player>().mList;
            }

            if (transform.childCount == 3)
            {
                transform.GetChild(0).GetComponent<Rigidbody2D>().simulated = false;
                transform.GetChild(1).GetComponent<Rigidbody2D>().simulated = false;
                transform.GetChild(2).GetComponent<Rigidbody2D>().simulated = false;
                transform.GetChild(0).parent = GameManager.instance.player.transform;
                transform.GetChild(0).parent = GameManager.instance.player.transform;
                transform.GetChild(0).parent = GameManager.instance.player.transform;
                GameManager.instance.player.transform.GetChild(4).localPosition = GameManager.instance.PosicionesToolKits[(int)GameManager.instance.player.GetComponent<Player>().mList];
                ++GameManager.instance.player.GetComponent<Player>().mList;
                GameManager.instance.player.transform.GetChild(5).localPosition = GameManager.instance.PosicionesToolKits[(int)GameManager.instance.player.GetComponent<Player>().mList];
                ++GameManager.instance.player.GetComponent<Player>().mList;
                GameManager.instance.player.transform.GetChild(6).localPosition = GameManager.instance.PosicionesToolKits[(int)GameManager.instance.player.GetComponent<Player>().mList];
                ++GameManager.instance.player.GetComponent<Player>().mList;
            }
        }
    }


}
