using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text nameText;
    public Text dialogText;

    private GameObject textPanel;
    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        textPanel = GameObject.Find("/Main Camera/Canvas/DialogPanel");
	}

    public void StartDialog(Dialog dialog)
    {
        Image imagePanel = textPanel.GetComponent<Image>();
        imagePanel.enabled = true;
        
        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndOfDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    private void EndOfDialog()
    {
        Image imagePanel = textPanel.GetComponent<Image>();
        imagePanel.enabled = false;
    }
}
