using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class MyTower : MonoBehaviour
{
    public TowerStat tower;

    public Text nameText;
    public Text costText;
    public GameObject lockSprite;
    public Currency currencyScript;



    void Update()
    {
        nameText.text = tower.myName.ToString();
        costText.text = "$" + tower.cost.ToString();

        CheckCurrency();
        CheckTower();
    }

    void CheckCurrency()
    {
        if (currencyScript.myCurrency >= tower.cost)
        {
            Lock(false);
        }
        else
        {
            Lock(true);
        }
    }

    void CheckTower()
    {
        if (tower.tower == null)
        {
            Lock(true);
        }
    }

    void Lock(bool lockMe)
    {
        if (lockMe == true)
        {
            lockSprite.SetActive(true);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            lockSprite.SetActive(false);
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
