using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadrearVerController : ParentItemController {

    [SerializeField] private GameEvent madrearEvent;
    [SerializeField] private GameEvent verEvent;
    
	// Use this for initialization
	void Start () {
        contextMenuItems = new List<ContextMenuItem>();
        Action<Image> madreate = new Action<Image>(MadreateAction);
        Action<Image> see = new Action<Image>(SeeAction);

        contextMenuItems.Add(new ContextMenuItem("Madrear", GameState.Instance.madreateSprite, sampleButton, madreate));
        contextMenuItems.Add(new ContextMenuItem("Ver", GameState.Instance.verSprite, sampleButton, see));
    }

    void MadreateAction(Image contextPanel)
    {
        PlayerInteract playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        playerInteract.SubscribeEvent(madrearEvent);
        Destroy(contextPanel.gameObject);
    }

    void SeeAction(Image contextPanel)
    {
        PlayerInteract playerInteract = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        playerInteract.SubscribeEvent(verEvent);
        Destroy(contextPanel.gameObject);
    }
}
