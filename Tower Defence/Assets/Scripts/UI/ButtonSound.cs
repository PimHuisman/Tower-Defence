using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonSound : MonoBehaviour
{
    public AudioClip mainButtonSound;
	
    public AudioSource source;

    public void PlaySound()
    {
        //source.clip = mainButtonSound;
        source.PlayOneShot(mainButtonSound);
    }
}
