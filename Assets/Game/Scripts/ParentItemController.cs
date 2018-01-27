﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ParentItemController : MonoBehaviour {

    public Button sampleButton;                         // sample button prefab
    protected List<ContextMenuItem> contextMenuItems;     // list of items in menu

    // Use this for initialization
    void Start () {
        // initialization is responsibility of the child classes
    }

    protected void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PopupMenu();
        }
    }

    private void PopupMenu()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        ContextMenuGenerator.Instance.CreateContextMenu(contextMenuItems, new Vector2(pos.x, pos.y));
    }

    private float holdTime = 0.8f;
    private float acumTime = 0;

    // Update is called once per frame
    protected void Update ()
    {
		if (Input.touchSupported && Input.touchCount > 0)
        {
            acumTime += Input.GetTouch(0).deltaTime;

            if (acumTime >= holdTime)
            {
                PopupMenu();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                acumTime = 0;
            }
        }
	}
}
