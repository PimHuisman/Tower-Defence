﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAnimManager : MonoBehaviour {
	public Animator myAnimator;
	public bool canOpen;
	public bool isOpen;
	public CamToSettings camToSettings;

	void Update () {
		if (Input.GetButton ("Fire1")) {
			if (canOpen) {
				myAnimator.Play ("OpenBridge");
				camToSettings.Go();
				camToSettings.SetAnimSpeed(1);
				myAnimator.SetFloat("Speed", 1);
				isOpen = true;
				canOpen = false;
			}
		}
	}

	void OnMouseEnter () {
		if (!isOpen) {
			myAnimator.Play ("BridgeOnMouseOver");
			myAnimator.SetFloat ("Speed", 1);
		}
	}

	void OnMouseExit () {
		if (!isOpen) {

			myAnimator.SetFloat ("Speed", -1);
			canOpen = false;
		}
	}

	public void FirstEventBOMO () {
		if (myAnimator.GetFloat ("Speed") < 0) {
			myAnimator.SetFloat ("Speed", 0);
			myAnimator.Play ("BridgeIdle");
		}
	}

	public void LastEventBOMO () {
		myAnimator.SetFloat ("Speed", 0);
		canOpen = true;
	}

	public void FirstEventOB () {
	}

	public void LastEventOB () {
		myAnimator.SetFloat ("Speed", 0);
	}

	public void LastEventCB () {
		myAnimator.SetFloat("Speed", 1);
		myAnimator.Play("BridgeIdle");
		isOpen = false;
	}

	public void ReverseBridgeOpen() {
		myAnimator.Play("CloseBridge");
		myAnimator.SetFloat("Speed", 1);
	
	}
}