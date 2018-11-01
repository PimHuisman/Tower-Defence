using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvFade : MonoBehaviour {
	public Animator myAnimator;

	void Start() {
		myAnimator.Play("CanvasFade");
	}
}
