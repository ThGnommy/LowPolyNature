using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicOff : MonoBehaviour {


    public AudioMixerSnapshot musicOff;

    // Use this for initialization

    private void OnTriggerEnter(Collider other)
    {
        musicOff.TransitionTo(2.5f);
    }

    private void Awake()
    {
        musicOff.TransitionTo(0);
    }
}
