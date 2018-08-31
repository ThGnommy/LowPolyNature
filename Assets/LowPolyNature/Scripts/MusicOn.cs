using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicOn : MonoBehaviour {

    public AudioMixerSnapshot musicOn;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        musicOn.TransitionTo(2.5f);
    }
}
