using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public GameObject panel;
    public GameObject oldPanel;
    public static bool settingsOpen = false;
    public void OpenSettings()
    {
        panel.SetActive(true);
        oldPanel.SetActive(false);
        settingsOpen = true;
    }

    public void CloseSettings()
    {
        panel.SetActive(false);
        oldPanel.SetActive(true);
        settingOpen = false;
    }

}