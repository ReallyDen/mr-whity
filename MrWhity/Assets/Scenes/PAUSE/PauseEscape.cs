using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEscape : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("escape") && !Settings.settingsOpen) {

            if (pause.paused) {
                pause.Continue();
            }
            else {
                pause.Pause();
            }

        }
    }
}
