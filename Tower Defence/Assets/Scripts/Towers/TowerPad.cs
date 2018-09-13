using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPad : MonoBehaviour
{
    private MouseToWorldSpace mouseScript;
    private BuildOrDestroy bodScript;
    private RaycastHit mouseHit;
    public bool isPressed;
    public TowerStat currentTower;
    private bool otherIsPressed;

    void Start()
    {
        mouseScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseToWorldSpace>();
        bodScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<BuildOrDestroy>();
    }

    void Update()
    {
        DetectMouse();
    }


    //Void to detect mouse
    void DetectMouse()
    {
        mouseHit = mouseScript.mouseHit;

        if (isPressed == false)
        {
            //Detect if mouse is hovering over tower pad
            if (mouseHit.collider == gameObject.transform.GetComponent<Collider>())
            {
                //Detect if user clicks on tower pad
                if (Input.GetButtonDown("Fire1"))
                {
                    foreach (GameObject pad in bodScript.towerPads)
                    {
                        if (pad.GetComponent<TowerPad>().isPressed == true)
                        {
                            otherIsPressed = true;
                        }
                    } 

                    if (otherIsPressed == false)
                    {
                        isPressed = true;
                    }

                    otherIsPressed = false;
                }
            }
        }
    }
}
