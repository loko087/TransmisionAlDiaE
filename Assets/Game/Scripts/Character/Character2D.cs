using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour {

    private Vector3 targetPosition;

    public float speed;

    public Animator characterAnimator;
    private bool walking = false;
	// Use this for initialization
	void Start () {
        targetPosition = this.transform.position;
       characterAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(Input.mousePosition + " World Position" + Camera.main.ScreenToWorldPoint(Input.mousePosition));
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            
        }

        if(Vector2.Distance(transform.position,targetPosition) > 0.3f)
        {
            if (!walking)
            {
                characterAnimator.SetTrigger("Walking");
                walking = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 1/speed);
        }else
        {
            if (walking)
            {
                characterAnimator.SetTrigger("Idle");
                walking = false;
            }
        }
	}
}
