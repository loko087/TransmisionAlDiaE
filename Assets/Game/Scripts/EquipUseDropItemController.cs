using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipUseDropItemController : ParentItemController {

	// Use this for initialization
	void Start () {
        contextMenuItems = new List<ContextMenuItem>();
        Action<Image> equip = new Action<Image>(EquipAction);
        Action<Image> use = new Action<Image>(UseAction);
        Action<Image> drop = new Action<Image>(DropAction);

        contextMenuItems.Add(new ContextMenuItem("Equipar", GameState.Instance.equipSprite, sampleButton, equip));
        contextMenuItems.Add(new ContextMenuItem("Usar", GameState.Instance.useSprite, sampleButton, use));
        contextMenuItems.Add(new ContextMenuItem("Tirar", GameState.Instance.dropSprite, sampleButton, drop));
    }

    void EquipAction(Image contextPanel)
    {
        Debug.Log("Equipped");
        Destroy(contextPanel.gameObject);
    }

    void UseAction(Image contextPanel)
    {
        Debug.Log("Used");
        Destroy(contextPanel.gameObject);
    }

    void DropAction(Image contextPanel)
    {
        Debug.Log("Dropped");
        Destroy(contextPanel.gameObject);
    }
}
