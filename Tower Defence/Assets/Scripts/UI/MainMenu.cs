using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void LaunchLevel(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void Quit() {
		Application.Quit();
	}
	
}
