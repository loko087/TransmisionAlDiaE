using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadrearVerController : ParentItemController {

	// Use this for initialization
	void Start () {
        contextMenuItems = new List<ContextMenuItem>();
        Action<Image> madreate = new Action<Image>(MadreateAction);
        Action<Image> see = new Action<Image>(SeeAction);

        contextMenuItems.Add(new ContextMenuItem("Madrear", sampleButton, madreate));
        contextMenuItems.Add(new ContextMenuItem("Ver", sampleButton, see));
    }

    void MadreateAction(Image contextPanel)
    {
        Debug.Log("Madreado");
        Destroy(contextPanel.gameObject);
    }

    void SeeAction(Image contextPanel)
    {
        Debug.Log("Visto");
        Destroy(contextPanel.gameObject);
    }
}
