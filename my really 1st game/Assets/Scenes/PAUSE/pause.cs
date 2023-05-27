using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject panel;
    public KeyCode spaceKey;

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}