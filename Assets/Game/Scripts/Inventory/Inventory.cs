using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


    public List<InventoryItem> items;
    public Character2D player;

    public InventoryItem carryingGameObject;


	// Use this for initialization
	void Start () {
        carryingGameObject = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CloseInventory();
        }

        if(carryingGameObject != null && Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (ray.collider != null)
            {
                Debug.Log("Colliding with " + ray.collider.name);
                if(ray.collider.gameObject.name == carryingGameObject.targetObject)
                {
                    Debug.Log("Drop it like it's hot");
                }
            }
        }
    }


    public void CloseInventory()
    {
        player.InventoryOpen = false;
        gameObject.SetActive(false);

        player.targetPosition = player.transform.position;

    }
}
