using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOrDestroy : MonoBehaviour
{
    public List<GameObject> towerPads;
    public GameObject currentPad;
    public GameObject buyPanel;
    public GameObject sellPanel;
    private TowerPad currentPadScript;

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

                }
                else
                {

                    sellPanel.SetActive(true);

                }

            }
            else
            {
                //currentPad = null;
            }
        }
    }

    public void Build(TowerStat towerToBuild)
    {

        print(currentPad.name);
        print("Building " + towerToBuild.myName);
        currentPadScript.currentTower = towerToBuild;
        GameObject newTower = Instantiate(towerToBuild.tower, currentPad.transform);
        newTower.transform.localPosition = Vector3.zero;
        buyPanel.SetActive(false);
        currentPadScript.isPressed = false;
    }

    public void Destroy()
    {

        TowerStat towerOnPad = currentPadScript.currentTower;
        print("Destroying " + towerOnPad.myName);
        Destroy(currentPad.transform.GetChild(2).gameObject);
        currentPadScript.currentTower = null;
        sellPanel.SetActive(false);
        currentPadScript.isPressed = false;
    }
}
