using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour {
    public GameObject overlay;
	public GameObject deathUI;

	public void Die() {
		print("Oof!");
		overlay.SetActive(false);
		deathUI.SetActive(true);
	}

	public void Retry() {
		
	}

	public void MainMenu() {
		//Go to main menu
	}

	public void Exit() {
		print("Quitting game...");
		Application.Quit();
	}
}
