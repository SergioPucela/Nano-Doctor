using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private bool canTalk = true; //Para saber si ya has hablado con el NPC
    public bool enableMove = true; //Para poder habilitar de nuevo los controles del jugador

    public GameObject continueButton;

    void Update()
    {
        if (textDisplay.text == sentences[index])
            continueButton.SetActive(true);
        else if (textDisplay.text == "")
            continueButton.SetActive(false);
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
            textDisplay.text = "";

        if (index >= sentences.Length - 1 && textDisplay.text == "")
            enableMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canTalk)
            if (collision.gameObject.name == "Jugador")
            {
                canTalk = false;
                enableMove = false;
                StartCoroutine(Type());
            }
    }

}
