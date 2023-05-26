using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public GameObject panel;
    public GameObject oldPanel;

    public void OpenSettings()
    {
        panel.SetActive(true);
        oldPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        panel.SetActive(false);
        oldPanel.SetActive(true);
    }

}