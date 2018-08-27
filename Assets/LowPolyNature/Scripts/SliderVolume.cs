using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderVolume : MonoBehaviour {

    public AudioMixer audioMixer;
	
    public void SetMasterVol(float masterVolume)
    {
        audioMixer.SetFloat("masterVolume", masterVolume);
    }

    public void SetAmbVol(float ambVolume)
    {
        audioMixer.SetFloat("ambVolume", ambVolume);
    }

    public void SetSfxVol(float sfxVolume)
    {
        audioMixer.SetFloat("sfxVolume", sfxVolume);
    }

    public void ClearVolume()
    {
        audioMixer.ClearFloat("masterVolume");
    }

}
