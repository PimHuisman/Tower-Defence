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
        costText.text = tower.cost.ToString();

        CheckCurrency();
    }

    void CheckCurrency()
    {
        if (currencyScript.myCurrency >= tower.cost)
        {
            lockSprite.SetActive(false);
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            lockSprite.SetActive(true);
            gameObject.GetComponent<Button>().interactable = false;
        }
    }


}
