using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource buttonSource;
    public void Exit()
    {
        Application.Quit();
        buttonSource.Play();
    }

    public void Game()
    {
        SceneManager.LoadScene(1);
        buttonSource.Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        buttonSource.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
        buttonSource.Play();
    }
    public void Controls()
    {
        SceneManager.LoadScene(2);
        buttonSource.Play();
    }
    public void Story()
    {
        SceneManager.LoadScene(3);
        buttonSource.Play();
    }

}
