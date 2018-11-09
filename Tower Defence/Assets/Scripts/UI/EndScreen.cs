using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject overlay;
    public GameObject deathUI;
    public GameObject blur;

    private Scene myScene;
	[SerializeField]string nextLevel; 
    public string menuSceneName;

    void Start()
    {
        myScene = SceneManager.GetActiveScene();
        blur.SetActive(false);
    }
    public void Next()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void Die()
    {
        print("Oof!");
        overlay.SetActive(false);
        deathUI.SetActive(true);
        blur.SetActive(true);
        Time.timeScale = 0;
    }

    public void Retry()
    {
        SceneManager.LoadScene(myScene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
