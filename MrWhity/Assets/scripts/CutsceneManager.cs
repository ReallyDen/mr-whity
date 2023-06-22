using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public PlayableDirector currentTimeline;
    void Start()
    { }
    void Awake()
    {
        currentTimeline = GetComponent<PlayableDirector>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentTimeline.time = currentTimeline.duration; ; //скипаем
        }
    }
}
