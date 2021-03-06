﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBanner : MonoBehaviour {

	Animator myAnimator;
	Animator camAnimator;
	public Animator textAnimator;
	float animSpeed;
	bool canClick;
	public GameObject mainCam;
	public CameraAnimatorManager camAnimManager;

	// Use this for initialization
	void Start () {
		myAnimator = gameObject.GetComponent<Animator> ();
		animSpeed = myAnimator.speed;
		myAnimator.SetFloat ("Speed", 0);
	}

	void Update () {
		if (!mainCam.activeSelf) {
			if (canClick) {
				if (Input.GetButtonDown ("Fire1")) {
					Play ();
				}
			}
		}
	}

	void Play () {
		textAnimator.Play ("TextFadeAway");
		camAnimManager.GoToPlay ();
	}

	void OnMouseEnter () {
		if (!mainCam.activeSelf) {
			SetAnimSpeed (1);
			canClick = true;
		}
	}

	public void OnMouseExit () {
		if (!mainCam.activeSelf) {
			SetAnimSpeed (-1);
			canClick = false;
		}
	}

	public void SetAnimSpeed (float speed) {
		print ("Setting float speed to " + speed);
		myAnimator.SetFloat ("Speed", speed);
	}
}