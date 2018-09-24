using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
	[SerializeField] GameObject pauseMenu;
	bool ispaused;
	
	void Start () 
	{
		ispaused = false;
	}
	
	void Update () 
	{
		if (Input.GetButtonDown("Cancel"))
		{
			ispaused = !ispaused;
		}

		if (ispaused)
		{
			Time.timeScale = 0;
			pauseMenu.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			pauseMenu.SetActive(false);
		}
	}
}
