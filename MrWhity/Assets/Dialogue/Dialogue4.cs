using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue4 : MonoBehaviour
{
    public GameObject panel;
    public Text TextDialog;
    public string[] message;
    public int soCool = 0;
    public bool StartDialog = false;

    void Start()
    {
        message[0] = "Приветствую тебя, новичек, в нашем небольшом городке, я его мэр Звездодед. (нажмите Е для продолжения)";
        message[1] = "Я также являюсь его основателем, с одним моим очень хорошим другом, но к сожалению, он не дожил до наших дней.. (нажмите Е для продолжения)";
        message[2] = "Раньше я был более ярким и светлым, но как видишь, старость дает о себе знать, он тоже был.. золотым, как и я. (Нажмите Е для продолжения) ";
        message[3] = "Вообщем, хочу тебе пожелать хорошо провести время. Даже если ты заглянул к нам не на долго, будем рады видеть тебя еще!";
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            panel.SetActive(true);
            TextDialog.text = message[soCool];
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
        if (StartDialog == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && soCool < message.Length)
            {
                soCool += 1;
                TextDialog.text = message[soCool];
            }
        }
    }
}
