using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToWorldSpace : MonoBehaviour
{
    private Ray mouseRay;
    public RaycastHit mouseHit;
    public bool printIfHit;

    // Update is called once per frame
    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out mouseHit))
        {
            if (printIfHit == true)
            {
                print("Mouse is hitting " + mouseHit.collider.name);
            }
        }

    }
}
