using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleModifier : MonoBehaviour {
	
	[Range(0, 10)]
	public float myTimeScale;

	void Update () {
		Time.timeScale = myTimeScale;
		print(Time.timeScale);
	}
}
