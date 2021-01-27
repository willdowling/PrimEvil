using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogue;
    public Text name;
    public Image profile;

    public GameObject dBox;
    public GameObject gameInfo;

    private bool isReady = true;

    public AudioSource snd;

    public Queue<string> sentences = new Queue<string>();


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isReady)
        {
            isReady = false;

            DisplayNextSenetence();
        }
        else
        {
            return;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        dBox.SetActive(true);
        gameInfo.SetActive(false);
        profile.sprite = dialogue.profile;
        name.text = dialogue.name;
        foreach(string sentence in dialogue.sentences)
        {
           sentences.Enqueue(sentence);
        }
        DisplayNextSenetence();
    }

    public void DisplayNextSenetence()
    {

        snd.Play();
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogue.text = sentence;
        isReady = true;
    }


    void EndDialogue()
    {

        dBox.SetActive(false);
        gameInfo.SetActive(true);
    }


}
