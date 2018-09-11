using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOrDestroy : MonoBehaviour
{
    public List<GameObject> towerPads;
	private GameObject currentPad;
	public GameObject buyPanel;
	public GameObject sellPanel;

    void Update()
    {
        foreach (GameObject pad in towerPads)
        {
            if (pad.GetComponent<TowerPad>().isPressed)
            {
				currentPad = pad;
                if (pad.GetComponent<TowerPad>().currentTower == null)
                {
                    buyPanel.SetActive(true);
                }
            } else {
				currentPad = null;
			}
        }
    }

    public void Build(TowerStat towerToBuild)
    {
		print("Building " + towerToBuild.myName);
		GameObject newTower = Instantiate(towerToBuild.tower, currentPad.transform.GetChild(1));
		newTower.transform.position = Vector3.zero;
    }

    void Destroy()
    {

    }
}
