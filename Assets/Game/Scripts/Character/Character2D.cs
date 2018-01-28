using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour {

    [System.NonSerialized]
    public Vector3 targetPosition;

    public float speed;

    public Animator characterAnimator;
    private bool walking = false;



    public GameObject Inventory;
    public bool InventoryOpen;
	// Use this for initialization
	void Start () {
        targetPosition = this.transform.position;
       characterAnimator = GetComponent<Animator>();
        InventoryOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!InventoryOpen) {
            if (Input.GetMouseButtonDown(0) && !GameState.Instance.eventWait)
            {
                //Debug.Log(Input.mousePosition + " World Position" + Camera.main.ScreenToWorldPoint(Input.mousePosition));
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            }

            if (Vector2.Distance(transform.position, targetPosition) > 0.3f)
            {
                if (!walking)
                {
                    characterAnimator.SetTrigger("Walking");
                    walking = true;
                }
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, 1 / speed);
            } else
            {
                if (walking)
                {
                    characterAnimator.SetTrigger("Idle");
                    walking = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenInventory();
                characterAnimator.SetTrigger("Idle");
            }

            }
	}


    public void OpenInventory()
    {
        this.Inventory.SetActive(true);
        this.InventoryOpen = true;
    }
}
