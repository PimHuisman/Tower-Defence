using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {
  public AudioMixer mainMixer;

  public void SetVolume (float volume) {
    mainMixer.SetFloat ("MasterMixer", volume);
  }

  public void SetRes1920 () {
    Screen.SetResolution (1920, 1080, false);
  }

  public void SetRes1280 () {
    Screen.SetResolution (1920, 1080, false);
  }

}