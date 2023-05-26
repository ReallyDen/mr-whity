using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public int sceneNumber;

    public void Transition()
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1f;
    }
}