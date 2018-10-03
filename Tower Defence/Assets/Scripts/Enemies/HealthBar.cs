using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject healthCanvas;
    public Image healthBar;
    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
    void Update()
    {
        healthCanvas.transform.LookAt(mainCamera.transform);
    }

    public void ChangeBar(float newHealth, float mainHealth)
    {
        float amount = newHealth / mainHealth;
		print(amount);
        healthBar.fillAmount = amount;
    }
}
