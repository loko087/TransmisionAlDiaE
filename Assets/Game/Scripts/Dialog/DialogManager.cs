﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text nameText;
    public Text dialogText;
    public Button nextButton;
    public Image speakerFace;

    public GameObject textPanel;
    private Queue<string> sentences;
    private bool isDialogOpen;
    public bool IsDialogOpen { get { return isDialogOpen; } }

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialog(Dialog dialog)
    {
        Image imagePanel = textPanel.GetComponent<Image>();
        imagePanel.enabled = true;

        nextButton.gameObject.SetActive(true);
        
        nameText.text = dialog.name;
        if (dialog.speakerFace != null) {
            speakerFace.sprite = dialog.speakerFace;
            speakerFace.gameObject.SetActive(true);
        } else speakerFace.gameObject.SetActive(false);


        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        isDialogOpen = true;
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if(isDialogOpen) dialogText.text += letter;
            yield return null;
        }
    }

    private void EndOfDialog()
    {
        Image imagePanel = textPanel.GetComponent<Image>();
        imagePanel.enabled = false;
        nameText.text = "";
        dialogText.text = "";
        nextButton.gameObject.SetActive(false);
        speakerFace.gameObject.SetActive(false);
        isDialogOpen = false;
    }
}
