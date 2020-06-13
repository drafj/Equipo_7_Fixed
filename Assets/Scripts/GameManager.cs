using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Direccion mDirec;
    public bool agarrarToolKit;
    public GameObject toolKitBlue ,toolKitGreen, toolKitRed;
    public GameObject gameOver, winner;
    public GameObject player;
    public Vector3[] PosicionesToolKits = new Vector3[4];
    public bool reparando = true;
    public bool[] activadorToolKits;
    public bool inGame;
    public bool pickBagReady;
    public bool enReparando = true;
    public bool bagReady;
    public bool reparandoAnim;
    public bool tranEquiparArma;
    public bool pause = true;
    public bool armaSacada;
    public int torreAzulReparada;
    public int torreVerdeReparada;
    public int torreRojaReparada;
    
    public float tiempo = 0;
    public float tiempoDeReset = 3;
    public float hP = 10f;

    public Text tiempoDeReparacion;

    public Text textoVida;
    public Text time;
    public Image dashColdDownUI;

    private void Awake()
    {
        pause = false;
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        PosicionesToolKits = new Vector3[4];
        bagReady = true;
    }

    void Start()
    {
        PosicionesToolKits[0] = new Vector3(-0.43f, 0.91f, 1.4f);
        PosicionesToolKits[1] = new Vector3(-0.43f, 1.39f, 1.3f);
        PosicionesToolKits[2] = new Vector3(-0.43f, 1.87f, 1.2f);
        PosicionesToolKits[3] = new Vector3(-0.43f, 1.88f, 1f);

        activadorToolKits = new bool[4];
    }

    void Update()
    {
        textoVida.text = "Life " + hP;
        tiempo += Time.deltaTime;
        time.text = "Time: " + tiempo.ToString("f0");
        if (torreRojaReparada == 2 &&  torreVerdeReparada == 2 && torreAzulReparada == 2 && tiempo <= 300f)
        {
            winner.SetActive(true);
            enReparando = false;
        }
        else if (tiempo >= 300f || hP <= 0)
        {
            gameOver.SetActive(true);
            tiempoDeReset -= Time.deltaTime;
            textoVida.text = "Life ";
            inGame = true;
        }
        if (tiempoDeReset <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}

public enum Direccion
{
    Derecha,
    Izquierda
}