﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ContextMenuItem
{
    // this class - just a box to some data

    public string text;             // text to display on button
    public Button button;           // sample button prefab
    public Action<Image> action;    // delegate to method that needs to be executed when button is clicked

    public ContextMenuItem(string text, Button button, Action<Image> action)
    {
        this.text = text;
        this.button = button;
        this.action = action;
    }
}

public class ContextMenuGenerator : MonoBehaviour {

    public Image contentPanel;
    public Canvas canvas;

    private static ContextMenuGenerator instance;

    public static ContextMenuGenerator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(ContextMenuGenerator)) as ContextMenuGenerator;
                if (instance == null)
                {
                    instance = new ContextMenuGenerator();
                }
            }
            return instance;
        }
    }

    public void CreateContextMenu(List<ContextMenuItem> items, Vector2 position)
    {
        // here we are creating and displaying Context Menu

        Image panel = Instantiate(contentPanel, new Vector3(position.x, position.y, 0), Quaternion.identity) as Image;
        panel.transform.SetParent(canvas.transform);
        panel.transform.SetAsLastSibling();
        panel.rectTransform.anchoredPosition = position;

        foreach (var item in items)
        {
            ContextMenuItem tempReference = item;
            Button button = Instantiate(item.button) as Button;
            Text buttonText = button.GetComponentInChildren(typeof(Text)) as Text;
            buttonText.text = item.text;
            button.onClick.AddListener(delegate { tempReference.action(panel); });
            button.transform.SetParent(panel.transform);
        }
    }
}
