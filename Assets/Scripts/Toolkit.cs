using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolkit : MonoBehaviour
{

    public ToolKitColor myColor;
     
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
            GameManager.instance.pickBagReady = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
            GameManager.instance.pickBagReady = false;
    }

    void Update()
    {
        if (transform.parent == GameManager.instance.player.transform && myColor == ToolKitColor.Blue)
        {
            GameManager.instance.activadorToolKits[0] = true;
        }
        else if (transform.parent != GameManager.instance.player.transform && myColor == ToolKitColor.Blue)
            GameManager.instance.activadorToolKits[0] = false;

        if (transform.parent == GameManager.instance.player.transform && myColor == ToolKitColor.Green)
        {
            GameManager.instance.activadorToolKits[1] = true;
        }
        else if (transform.parent != GameManager.instance.player.transform && myColor == ToolKitColor.Green)
            GameManager.instance.activadorToolKits[1] = false;

        if (transform.parent == GameManager.instance.player.transform && myColor == ToolKitColor.Red)
        {
            GameManager.instance.activadorToolKits[2] = true;
        }
        else if (transform.parent != GameManager.instance.player.transform && myColor == ToolKitColor.Red)
            GameManager.instance.activadorToolKits[2] = false;
    }
}

public enum ToolKitColor
{
    Blue,
    Green,
    Red
}