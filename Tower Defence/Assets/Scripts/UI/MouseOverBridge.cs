using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverBridge : MonoBehaviour {
	public Animator myAnimator;
	float animSpeed;
	public bool isOver;
	public bool isClick;

	// Use this for initialization
	void Start () {
		animSpeed = myAnimator.speed;
		print (myAnimator.name + myAnimator.speed);

		myAnimator.SetFloat ("Speed", 0);
	}

	void Update () {
		if (isOver) {
			if (Input.GetButton ("Fire1")) {

			}
		}
	}

	void OnMouseEnter () {
		isOver = true;
		//print ("Mouse entered.");
		SetAnimSpeed (1);
	}

	public void OnMouseExit () {
		isOver = false;
		SetAnimSpeed (-1);
	}

	public void SetAnimSpeed (float speed) {
		//print ("Setting float speed to " + speed);
		myAnimator.SetFloat ("Speed", speed);
	}

	public void Event () {
		if (myAnimator.speed < 0) {
			SetAnimSpeed(1);
		} else {
			print(myAnimator.speed);
			SetAnimSpeed(0);
		}
	}
}