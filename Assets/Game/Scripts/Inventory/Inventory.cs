using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    public List<InventoryItem> items;
    public Character2D player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CloseInventory();
        }
    }


    public void CloseInventory()
    {
        player.InventoryOpen = false;
        gameObject.SetActive(false);

        player.targetPosition = player.transform.position;

    }
}
