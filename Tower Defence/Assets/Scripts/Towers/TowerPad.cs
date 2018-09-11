using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPad : MonoBehaviour
{
    public MouseToWorldSpace mouseScript;
    private RaycastHit mouseHit;
    public bool isPressed;
    public TowerStat currentTower;


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
            if (mouseHit.collider == gameObject.transform.GetComponent<Collider>() )
            {
                print("Mouse ray is hitting the tower pad.");
                //Detect if user clicks on tower pad
                if (Input.GetButtonDown("Fire1"))
                {                    
                    isPressed = true;
                }
            }
        }
    }
}
