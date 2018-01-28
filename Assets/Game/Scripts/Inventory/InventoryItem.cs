using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour{

    public Image graphic;
    public bool followMouse;
    public GameObject mouseobject;
    private Transform originalPosition;
	// Use this for initialization
	void Start () {
        originalPosition = transform;
        followMouse = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            followMouse = false;
            mouseobject.SetActive(false);
            this.GetComponent<Image>().CrossFadeAlpha(1.0f, 0.25f, false);
        }

        if (followMouse)
        {
            //transform.position = Input.mousePosition;
            mouseobject.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
        }
    
	}


    public void FollowMouse()
    {
        Debug.Log("soemthing");
        mouseobject.SetActive(true);
        this.GetComponent<Image>().CrossFadeAlpha(0.5f,0.25f,false);
        followMouse = true;
    }


}
