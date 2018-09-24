using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOrDestroy : MonoBehaviour
{
    public GameObject[] towerPads;
    public GameObject currentPad;
    public GameObject buyPanel;
    public GameObject sellPanel;
    public GameObject blur;
    private TowerPad currentPadScript;
    public GameObject particles;

    void Start() {
        towerPads = GameObject.FindGameObjectsWithTag("Tower Pad");
    }

    void Update()
    {
        foreach (GameObject pad in towerPads)
        {
            if (pad.GetComponent<TowerPad>().isPressed)
            {
                currentPad = pad;
                currentPadScript = currentPad.GetComponent<TowerPad>();

                if (currentPadScript.currentTower == null)
                {
                    buyPanel.SetActive(true);
                    Vector3 panelPos = Camera.main.WorldToScreenPoint(currentPad.transform.GetChild(0).position);
                    print(panelPos);
                    buyPanel.transform.position = panelPos;
                    blur.SetActive(true);
                }
                else
                {
                    sellPanel.SetActive(true);
                    Vector3 panelPos = Camera.main.WorldToScreenPoint(currentPad.transform.GetChild(0).position);
                    sellPanel.transform.position = panelPos;
                    blur.SetActive(true);
                }
            }
        }
    }

    public void IsNotPressed() {
        currentPadScript.isPressed = false;
    }

    public void Build(TowerStat towerToBuild)
    {
        print(currentPad.name);
        print("Building " + towerToBuild.myName);
        Particles();
        currentPadScript.currentTower = towerToBuild;
        GameObject newTower = Instantiate(towerToBuild.tower, currentPad.transform);
        newTower.transform.localPosition = Vector3.zero;
        currentPadScript.isPressed = false;
        buyPanel.SetActive(false);
        blur.SetActive(false);
    }

    public void Destroy()
    {
        TowerStat towerOnPad = currentPadScript.currentTower;
        print("Destroying " + towerOnPad.myName);
        Particles();
        Destroy(currentPad.transform.GetChild(2).gameObject);
        currentPadScript.currentTower = null;
        currentPadScript.isPressed = false;
        sellPanel.SetActive(false);
        blur.SetActive(false);
    }

    public void Particles() {
        GameObject parts = Instantiate(particles, currentPad.transform.GetChild(1).position, particles.transform.rotation);
        parts.GetComponent<ParticleSystem>().Play();
        Destroy(parts, 1);
    }
}
