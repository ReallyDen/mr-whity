using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPanelManager : MonoBehaviour
{
    public GameObject panel;
    // public GameObject oldPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            panel.SetActive(true);
          //  oldPanel.SetActive(false);
        }
    }
}
