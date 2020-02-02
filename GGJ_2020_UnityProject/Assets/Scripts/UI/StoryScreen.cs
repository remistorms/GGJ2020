using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StoryScreen : MonoBehaviour
{
    public Dialogue dialogue;
    public int currentSentenceIndex;
    public string currentSentence;
    public TextMeshProUGUI dialogueLabel;
    public float letterPause = 0.1f;
    public bool hasFinished = true;

    public void TypeSentence(string sentence)
    {
        StartCoroutine(_TypeSentence(sentence));
    }

    IEnumerator _TypeSentence(string sentence)
    {
        hasFinished = false;
        string[] array = sentence.Split(' ');
        dialogueLabel.text = array[0];
        for (int i = 1; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause);
            dialogueLabel.text += " " + array[i];
        }
        hasFinished = true;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            NextDialogue();
        }
    }

    public void NextDialogue()
    {
        if (hasFinished)
        {
            currentSentenceIndex++;
            if (currentSentenceIndex < dialogue.sentences.Length)
            {
                TypeSentence(dialogue.sentences[currentSentenceIndex]);
            }
            else
            {
                Debug.Log("START GAMEPLAY HERE");
                ManagerGame.instance.StartGame();
            }
        }
    }
}
