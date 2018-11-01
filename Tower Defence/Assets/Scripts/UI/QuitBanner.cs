using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBanner : MonoBehaviour {

	Animator myAnimator;
	float animSpeed;
	bool canClick;
	public GameObject mainCam;

	// Use this for initialization
	void Start () {
		myAnimator = gameObject.GetComponent<Animator> ();
		animSpeed = myAnimator.speed;
		myAnimator.SetFloat ("Speed", 0);
	}

	void Update () {
		if (canClick) {
			if (Input.GetButtonDown ("Fire1")) {
				if (!mainCam.activeSelf) {
					Quit ();
				}
			}
		}
	}

	void Quit () {
		print("Quitting!");
		Application.Quit ();
	}

	void OnMouseEnter () {
		SetAnimSpeed (1);
		canClick = true;
	}

	public void OnMouseExit () {
		SetAnimSpeed (-1);
		canClick = false;
	}

	public void SetAnimSpeed (float speed) {
		print ("Setting float speed to " + speed);
		myAnimator.SetFloat ("Speed", speed);
	}
}