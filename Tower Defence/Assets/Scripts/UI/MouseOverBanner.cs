using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverBanner : MonoBehaviour {
	Animator myAnimator;
	float animSpeed;

	// Use this for initialization
	void Start () {

		myAnimator = gameObject.GetComponent<Animator> ();
		animSpeed = myAnimator.speed;
		myAnimator.SetFloat ("Speed", 0);
	}

	void Update () {

	}

	void OnMouseEnter () {
		SetAnimSpeed (1);
	}

	public void OnMouseExit () {
		SetAnimSpeed (-1);
	}

	public void SetAnimSpeed (float speed) {
		print ("Setting float speed to " + speed);
		myAnimator.SetFloat ("Speed", speed);
	}
}