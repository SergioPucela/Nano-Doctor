using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameDisplay;
    public string NPC_Name;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    public PlayerInput Input;

    public bool dialogEnd = false;

    public GameObject continueButton;
    public GameObject dialogBox;

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
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyAI"))
            {
                EnemigoVolador AI = enemy.GetComponent<EnemigoVolador>();
                AI.enemyView = 15f;
            }
            dialogBox.SetActive(false);
            Input.enabled = true;
            index = 0;
            dialogEnd = true;
        }
    }

    public void DialogStart()
    {
        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("EnemyAI"))
        {
            EnemigoVolador AI = enemy.GetComponent<EnemigoVolador>();
            AI.enemyView = 0.01f;
        }
        dialogBox.SetActive(true);
        nameDisplay.text = NPC_Name;
        Input.enabled = false;
        StartCoroutine(Type());
    }

}
