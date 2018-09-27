using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject blur;
    public GameObject optionsMenu;

    public bool isPaused;
	public ButtonSound buttonSound;

    public TimeScaleModifier tsModifier;

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

            tsModifier.myTimeScale = 0;
            isPaused = true;
        }
        else
        {
			pauseMenu.SetActive(false);
            blur.SetActive(false);
            optionsMenu.SetActive(false);

			tsModifier.myTimeScale = 1;
			isPaused = false;	
        }
    }

	
}
