using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject credits;
    public void Play()
    {
        SceneManager.LoadScene("A_scene");
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
