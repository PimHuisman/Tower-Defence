using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPad : MonoBehaviour
{
    public bool isBought;
    public MouseToWorldSpace myMouse;
    private RaycastHit mouseHit;
    public GameObject buyPanel;
    public GameObject sellPanel;
    public GameObject uiPoint;
    public TowerStat myTower;

    // Use this for initialization
    void Start()
    {
        buyPanel.SetActive(false);
		sellPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouse();
    }

    void CheckMouse()
    {
        mouseHit = myMouse.mouseHit;

        if (mouseHit.collider == gameObject.GetComponent<Collider>())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (isBought == false)
                {
                    ShowBuyPanel();
                }
                else
                {
                    ShowSellPanel();
                }
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            HidePanel();
        }
    }

    void ShowBuyPanel()
    {
        buyPanel.SetActive(true);
        buyPanel.GetComponent<CurrentPad>().myPad = gameObject;
        Vector3 panelPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        buyPanel.transform.position = panelPos;
    }

    void ShowSellPanel()
    {
        sellPanel.SetActive(true);
        sellPanel.GetComponent<CurrentPad>().myPad = gameObject;
        Vector3 panelPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        sellPanel.transform.position = panelPos;
    }

    public void HidePanel()
    {
        buyPanel.SetActive(false);
    }
}
