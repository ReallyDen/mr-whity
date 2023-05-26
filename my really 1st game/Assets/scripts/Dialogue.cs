using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject panel;
    public Text TextDialog;
    public string[] message;
    public bool StartDialog = false;

    void Start()
    {
        message[0] = "Приветствую тебя в Голден тауне!! В наших краях редко встретишь посетителей, поэтому я очень рад тебя видеть!    (нажмите Е для продолжения)";
        message[1] = "Иди прямо. Там ты встретишь нашего мэра - Звездодеда. Он расскажет о нашем городе по-подробнее!";
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            panel.SetActive(true);
            TextDialog.text = message[0];
            StartDialog = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panel.SetActive(false);
        StartDialog = false;
    }

     void Update()
    {
        if(StartDialog == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TextDialog.text = message[1];
            }
        }
    }
}
