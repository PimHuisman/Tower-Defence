using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPad : MonoBehaviour
{
    public MouseToWorldSpace mouseScript;
    public BuildOrDestroy bodScript;
    private RaycastHit mouseHit;
    public bool isPressed;
    public TowerStat currentTower;
    private bool otherIsPressed;
    public AudioSource mySource;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    private bool isPlaying;
    Renderer myRend;
    List<Material> myMats = new List<Material>();
    List<Color> normalColor = new List<Color>();
    List<Color> highlightColor = new List<Color>();
    public Color colorToAdd;

    void Start()
    {
        FindObjects();
        CheckForRenderer();

    }

    void CheckForRenderer()
    {
        if (GetComponent<Renderer>() != null)
        {
            //print("I have a renderer!");
            myRend = GetComponent<Renderer>();
            //print("I have " + myRend.materials.Length + " materials.");

            MakeColor();
        }
        else
        {
            print("Missing renderer!");
        }

        MakeColor();
    }

    void FindObjects()
    {
        //mouseScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseToWorldSpace>();
        //bodScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<BuildOrDestroy>();
    }

    void MakeColor()
    {
        for (int i = 0; i < myRend.materials.Length; i++)
        {
            myMats.Add(myRend.materials[i]);

            normalColor.Add(myMats[i].color);

            Color newColor = normalColor[i] + colorToAdd;

            highlightColor.Add(newColor);
        }
    }

    void Highlight(bool hl)
    {
        if (hl == true)
        {
            for (int i = 0; i < myRend.materials.Length; i++)
            {
                myRend.materials[i].color = highlightColor[i];
            }
        }
        else
        {
            for (int i = 0; i < myRend.materials.Length; i++)
            {
                myRend.materials[i].color = normalColor[i];
            }
        }
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
