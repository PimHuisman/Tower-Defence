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
    public AudioSource mySource;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    private bool isPlaying;
    Renderer myRend;
    List<Material> myMats;

    void Start()
    {
        FindObjects();
        MakeColor();
        if (GetComponent<Renderer>() != null)
        {
            print("I have a renderer!");
            myRend = GetComponent<Renderer>();
            print("I have " + myRend.materials.Length + " materials.");
        }
        else
        {
            print("Missing renderer!");
        }
        //myRend = GetComponent<MeshRenderer>();

    }

    void FindObjects()
    {
        mouseScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseToWorldSpace>();
        bodScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<BuildOrDestroy>();
    }

    void MakeColor()
    {

    }

    void Highlight(bool hl)
    {

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
                Highlight(true);

                if (isPlaying == false)
                {
                    PlaySound(hoverSound, true);
                    isPlaying = true;
                }


                //Detect if user clicks on tower pad
                if (Input.GetButtonDown("Fire1"))
                {
                    PlaySound(clickSound, true);

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
            else
            {
                Highlight(false);
                PlaySound(null, false);
                isPlaying = false;
            }
        }
    }


    void PlaySound(AudioClip clip, bool play)
    {
        if (play == true)
        {
            //mySource.clip = clip;
            mySource.PlayOneShot(clip);
        }
        else
        {
            //mySource.Stop();
        }
    }
}
