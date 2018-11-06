using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOrDestroy : MonoBehaviour
{
    public GameObject[] towerPads;
    public GameObject currentPad;
    public GameObject buyOutOfBounds;
    public GameObject buyPanel;
    public GameObject sellPanel;
    public GameObject blur;
    private TowerPad currentPadScript;
    public GameObject particles;
    public AudioClip placementSound;
    public AudioClip sellSound;

    private AudioSource placementSource;

    public Currency currencyScript;
    public float sellMultiplier;

    void Start()
    {
        towerPads = GameObject.FindGameObjectsWithTag("Tower Pad");
        buyOutOfBounds.SetActive(false);
        sellPanel.SetActive(false);
    }

    void Update()
    {
        foreach (GameObject pad in towerPads)
        {
            if (pad.GetComponent<TowerPad>().isPressed)
            {
                currentPad = pad;
                placementSource = currentPad.GetComponent<AudioSource>();

                currentPadScript = currentPad.GetComponent<TowerPad>();

                if (currentPadScript.currentTower == null)
                {
                    buyOutOfBounds.SetActive(true);
                    Vector3 panelPos = Camera.main.WorldToScreenPoint(currentPad.transform.GetChild(0).position);
                    //print(panelPos);
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

    public void IsNotPressed()
    {
        currentPadScript.isPressed = false;
    }

    public void Build(MyTower towerToBuild)
    {
        currencyScript.myCurrency -= towerToBuild.tower.cost;
        PlayParticles();
        PlaySound(placementSound);
        currentPadScript.currentTower = towerToBuild.tower;
        GameObject newTower = Instantiate(towerToBuild.tower.tower, currentPad.transform);
        newTower.transform.localPosition = Vector3.zero;
        currentPadScript.isPressed = false;
        buyOutOfBounds.SetActive(false);
        blur.SetActive(false);
    }

    public void Destroy()
    {
        TowerStat towerOnPad = currentPadScript.currentTower;
        currencyScript.AddCurrency(towerOnPad.cost * sellMultiplier);
        PlayParticles();
        PlaySound(sellSound);
        Destroy(currentPad.transform.GetChild(2).gameObject);
        currentPadScript.currentTower = null;
        currentPadScript.isPressed = false;
        sellPanel.SetActive(false);
        blur.SetActive(false);
    }

    public void PlayParticles()
    {
        GameObject parts = Instantiate(particles, currentPad.transform.GetChild(1).position, particles.transform.rotation);
        ParticleSystem partSystem = parts.GetComponent<ParticleSystem>();
        partSystem.Play();
        Destroy(parts, partSystem.main.duration);
    }

    public void PlaySound(AudioClip clip)
    {
        placementSource.PlayOneShot(clip);
        //print("Playing " + clip.name);
    }
}
