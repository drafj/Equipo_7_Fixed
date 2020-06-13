using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moviment : MonoBehaviour
{
    public float speed = 40;
    public float force;
    public float fillingDashBar;
    Rigidbody2D rgbd;
    public bool jump = false;
    public bool dash = true;
    public static bool bulletDirection;
    public AudioSource walking;
    public AudioSource jumping;
    public DashDirection mDashDirec;
    public Animator anim;
    public CharacterController2D controller;
    [SerializeField] float horizontalMove = 0;

    //booleanos de las animaciones

    public bool idle;
    public bool walk;
    public bool dashing;
    public bool jumpAnim;
    public bool pickUp;
    public bool thor;
    public bool death;
    public bool sacarArma;
    public bool guardarArma;
    public bool armaFuera;
    public bool cajasPesadas;
    public bool caminandoArma;


    private void Awake()
    {
        bulletDirection = false;
        dash = true;
        idle = true;
        walk = false;
        dashing = false;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController2D>();
        fillingDashBar = 3;
    }
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        InvokeRepeating("Walking", 0.3f, 0.3f);
        walking.mute = true;
    }

    IEnumerator DashColdDown()
    {
        dash = false;
        dashing = true;
        fillingDashBar = 0;
        yield return new WaitForSeconds(3);
        dash = true;
        dashing = false;
    }

    void Update()
    {
        //MovimentAndJump();
        //CambiadorDeOrientacion();
        anim.SetBool("Pj_Idle", idle);
        anim.SetBool("Pj_Walking", walk);
        anim.SetBool("Pj_Dash", dashing);
        anim.SetBool("Pj_Thor", GameManager.instance.reparandoAnim);
        anim.SetBool("Pj_Sacando_Arma", GameManager.instance.tranEquiparArma);
        anim.SetBool("Pj_Arma_Walking", caminandoArma);
        
        if (GameManager.instance.inGame == false)
        {


            if (GameManager.instance.armaSacada && walk)
                caminandoArma = true;
            else
                caminandoArma = false;

            if (mDashDirec == DashDirection.Idle)
                dashing = false;
            else
                dashing = true;

            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                jumping.Play();
                walking.mute = true;
            }

            if (horizontalMove == 0)
            {
                walking.mute = true;
                idle = true;
                walk = false;
            }
            else if (horizontalMove >= 0.1)
            {
                bulletDirection = false;
                idle = false;
                walk = true;
            }
            else if (horizontalMove <= 0.1)
            {
                bulletDirection = true;
                idle = false;
                walk = true;
            }

            GameManager.instance.dashColdDownUI.GetComponent<Image>().fillAmount = (fillingDashBar / 3);
        }
        else
        {
            horizontalMove = 0;
            walking.mute = true;
            idle = true;
            walk = false;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.inGame)
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x == 1 && dash && !GameManager.instance.inGame)
        {
            rgbd.velocity = Vector2.right * 100;
            StartCoroutine(DashColdDown());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && transform.localScale.x == -1 && dash && !GameManager.instance.inGame)
        {
            rgbd.velocity = Vector2.left * 100;
            StartCoroutine(DashColdDown());
        }

        if (!dash && fillingDashBar >= 0 && fillingDashBar <= 3)
        {
            fillingDashBar += Time.fixedDeltaTime;
        }

        if (fillingDashBar >= 3)
        {
            fillingDashBar = 3;
        }
    }

    /*void MovimentAndJump()
    {
        if (GameManager.instance.enReparando == true)
        {
            if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift) && dash)
            {
                dash = false;
                mDashDirec = DashDirection.Right;
                rgbd.velocity = Vector2.right * 150;
                StartCoroutine(DashColdDown());
                idle = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GameManager.instance.mDirec = Direccion.Derecha;
                rgbd.velocity = Vector2.right * speed;
                bulletDirection = false;
                idle = false;
                walk = true;
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift) && dash)
            {
                dash = false;
                mDashDirec = DashDirection.Left;
                rgbd.velocity = Vector2.left * 150;
                StartCoroutine(DashColdDown());
                idle = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                GameManager.instance.mDirec = Direccion.Izquierda;
                rgbd.velocity = Vector2.left * speed;
                bulletDirection = true;
                idle = false;
                walk = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && jump == true)
            {
                rgbd.AddForce(Vector2.up * force);
                jumping.Play();
                walking.mute = true;
                idle = false;
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                walking.mute = true;
                idle = true;
                walk = false;
            }

        }
        
    }*/

    void Walking()
    {
        walking.Play();
    }

    /*void CambiadorDeOrientacion()
    {
        if (GameManager.instance.mDirec == Direccion.Derecha)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }*/
    private void OnCollisionStay2D(Collision2D collision)
    {
        /*if (collision.transform.tag == "Terrain" || collision.transform.tag == "ToolKit")
        {
            jump = true;
        }*/
        if (collision.transform.tag == "Terrain" || collision.transform.tag == "ToolKit")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                walking.mute = false;
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
               walking.mute = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Terrain" || collision.transform.tag == "ToolKit")
        {
            //jump = false;
            walking.mute = true;
        }
    }
}

public enum DashDirection
{
    Idle,
    Right,
    Left
}