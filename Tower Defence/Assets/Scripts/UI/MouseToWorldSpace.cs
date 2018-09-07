using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToWorldSpace : MonoBehaviour {
	private Ray mouseRay;
	public RaycastHit mouseHit;

	// Update is called once per frame
	void Update () {
		mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(mouseRay, out mouseHit)) {
			
		}

	}
}
