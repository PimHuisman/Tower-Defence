using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject blur;
    public bool isPaused;
	public ButtonSound buttonSound;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame();
			buttonSound.PlaySound();
        }
    }


    public void PauseGame()
    {
        if (isPaused == false)
        {
            pauseMenu.SetActive(true);
            blur.SetActive(true);

            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
			pauseMenu.SetActive(false);
            blur.SetActive(false);

			Time.timeScale = 1;
			isPaused = false;	
        }
    }

	
}
