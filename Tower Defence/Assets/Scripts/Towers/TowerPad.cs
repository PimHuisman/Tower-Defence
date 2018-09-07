using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPad : MonoBehaviour {
	public MouseToWorldSpace myMouse;
	private RaycastHit mouseHit;

	public GameObject buyPanel;
	public GameObject uiPoint;


	// Use this for initialization
	void Start () {
		buyPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		CheckMouse();
		
	}

	void CheckMouse () {
		mouseHit = myMouse.mouseHit;

		if(mouseHit.collider == gameObject.GetComponent<Collider>()) {
			if(Input.GetButtonDown("Fire1")) {
				ShowPanel();
			}
		}

		if(Input.GetButtonDown("Fire2")) {
		HidePanel();
		}
	}

	void ShowPanel () {
		buyPanel.SetActive(true);
		
		Vector3 panelPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		buyPanel.transform.position = panelPos;
	}

	void HidePanel () {
		buyPanel.SetActive(false);
	}
}
