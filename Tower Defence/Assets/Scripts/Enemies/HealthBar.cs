using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public GameObject healthCanvas;
	public Image healthBar;
	public GameObject mainCamera;

	void Start() {
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	void Update () {
		healthCanvas.transform.LookAt(mainCamera.transform);
	}

	void ChangeBar() {
		
		//healthBar.fillAmount
	}
}
