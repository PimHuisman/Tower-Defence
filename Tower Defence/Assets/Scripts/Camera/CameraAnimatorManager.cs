using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimatorManager : MonoBehaviour {
	public Animator myAnimator;
	public GameObject mainCam;
	public GameObject manager;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
		canvas.SetActive(false);
		mainCam.SetActive(false);
		manager.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void FirstEvent () {
		if (myAnimator.GetFloat ("Speed") < 0) {
			myAnimator.SetFloat ("Speed", 0);
		}
	}

	public void GoToSet () {
		myAnimator.Play ("GoToSettings");
		myAnimator.SetFloat ("Speed", 1);
	}

	public void SetToMenu () {
		myAnimator.SetFloat ("Speed", -1);
	}

	public void GoToPlay () {
		myAnimator.Play ("GoToPlay");
		myAnimator.SetFloat ("Speed", 1);
	}

	public void LastEventGTB () {
		myAnimator.SetFloat ("Speed", 0);
		mainCam.SetActive (true);
		manager.SetActive(true);
		//canvas.SetActive(true);
		gameObject.SetActive (false);

	}

	public void SetAnimSpeed (float speed) {
		//print ("Setting float speed to " + speed);
		myAnimator.SetFloat ("Speed", speed);

	}
}