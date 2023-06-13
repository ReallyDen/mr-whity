using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class pause : MonoBehaviour
{
    public static GameObject panel;
    public static KeyCode spaceKey;
    public static bool paused = false;

    public static void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public static void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}