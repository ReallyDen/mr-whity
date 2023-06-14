using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEscape : MonoBehaviour
{

    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown("escape")) {

            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
