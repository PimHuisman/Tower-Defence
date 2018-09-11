﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyTower : MonoBehaviour
{
    public GameObject myPad;
    private TowerStat myTowerStats;
    public Currency currencyScript;
    private float myCurrency;
    public GameObject buyLock;
    public bool isBought;
    public CurrentPad myCurrentPad;
    public float percentageOfCash;
    void Start()
    {
        //myTowerStats = myTower.GetComponent<ThisTower>().thisTower;
        ToggleLock(true);
    }

    void Update()
    {
        myCurrency = currencyScript.myCurrency;
		
        myTowerStats = myPad.GetComponent<ThisTower>().thisTower;
		
        if (myCurrentPad.myPad.GetComponent<TowerPad>().isBought == false)
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
        myCurrentPad.myPad.GetComponent<TowerPad>().myTower = myTowerStats;
        myCurrentPad.myPad.GetComponent<TowerPad>().HidePanel();
        myCurrentPad.myPad.GetComponent<TowerPad>().isBought = true;
    }

    public void Sell()
    {
        isBought = false;
        currencyScript.myCurrency += myTowerStats.cost * percentageOfCash;
        myCurrentPad.myPad.GetComponent<TowerPad>().myTower = null;
        myCurrentPad.myPad.GetComponent<TowerPad>().HidePanel();
        myCurrentPad.myPad.GetComponent<TowerPad>().isBought = true;
    }

}