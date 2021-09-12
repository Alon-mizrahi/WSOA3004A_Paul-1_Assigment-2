using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject credits;
    public GameObject howToPlay;

    public void Play()
    {
        SceneManager.LoadScene("A_scene");
    }

    public void HowToPlayOpen()
    {
        howToPlay.SetActive(true);
    }

    public void HowToPlayClose()
    {
        howToPlay.SetActive(false);
    }

    public void CreditsOpen()
    {
        credits.SetActive(true);
    }

    public void CreditsClose()
    {
        credits.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
