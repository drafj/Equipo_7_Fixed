using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public GameObject pauseMenu;
    public GameObject pauseRestart;
    public AudioSource pauseSound;
    bool unpause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && unpause == true)
        {
            pause.SetActive(false);
            pauseMenu.SetActive(false);
            pauseRestart.SetActive(false);
            pauseSound.Play();
            unpause = false;
            GameManager.instance.pause = false;
            GameManager.instance.enReparando = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && unpause == false)
        {
            pause.SetActive(true);
            pauseMenu.SetActive(true);
            pauseRestart.SetActive(true);
            pauseSound.Play();
            unpause = true;
            GameManager.instance.pause = true;
            GameManager.instance.enReparando = false;
        }
    }
}
