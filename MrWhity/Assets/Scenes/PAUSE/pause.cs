using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject panel;
    public KeyCode spaceKey;
    public bool paused = false;

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}