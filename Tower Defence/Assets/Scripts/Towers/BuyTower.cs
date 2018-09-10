using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyTower : MonoBehaviour
{
    public GameObject myTower;
    private TowerStat myTowerStats;
    public Currency currencyScript;
    private int myCurrency;
    public GameObject buyLock;
    public bool isBought;
    void Start()
    {
        myTowerStats = myTower.GetComponent<ThisTower>().thisTower;
        ToggleLock(true);

    }

    void Update()
    {
        myCurrency = currencyScript.myCurrency;

        if (isBought == false)
        {
            if (myCurrency >= myTowerStats.cost)
            {
                ToggleLock(false);
            }
            else
            {
                ToggleLock(true);
            }
        }
        else
        {
            ToggleLock(true);
        }
    }

    void ToggleLock(bool lockMe)
    {

        if (lockMe == true)
        {
            gameObject.GetComponent<Button>().interactable = false;
            buyLock.SetActive(true);
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            buyLock.SetActive(false);
        }
    }

    public void Buy()
    {
        isBought = true;
        currencyScript.myCurrency -= myTowerStats.cost;
    }

}
