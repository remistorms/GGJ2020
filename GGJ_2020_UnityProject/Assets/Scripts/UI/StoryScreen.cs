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

    public void TypeSentence(string sentence)
    {
        StartCoroutine(_TypeSentence(sentence));
    }

    IEnumerator _TypeSentence(string sentence)
    {
        string[] array = sentence.Split(' ');
        dialogueLabel.text = array[0];
        for (int i = 1; i < array.Length; ++i)
        {
            yield return new WaitForSeconds(letterPause);
            dialogueLabel.text += " " + array[i];
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TypeSentence("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries,");
        }
    }

    public void NextDialogue()
    {
        currentSentenceIndex++;
        if (currentSentenceIndex < dialogue.sentences.Length)
        {
            TypeSentence(dialogue.sentences[currentSentenceIndex]);
        }
        else
        {
            //TODO Fade In To gameplay
            Debug.Log("START GAMEPLAY HERE");
        }

    }
}
