using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToSettings : MonoBehaviour {
	public Animator myAnimator;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void FirstEvent () {
		if (myAnimator.GetFloat ("Speed") < 0) {
			myAnimator.SetFloat ("Speed", 0);
		}
	}

	public void Go () {
		myAnimator.SetTrigger ("Activate");
	}

	public void SetAnimSpeed (float speed) {
		//print ("Setting float speed to " + speed);
		myAnimator.SetFloat ("Speed", speed);
	}
}