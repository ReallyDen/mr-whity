using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEscape : MonoBehaviour
{
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            if (pause.paused) {
                pause.Continue();
            }
            else {
                pause.Pause();
            }
        }
    }
}
