using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsSound : MonoBehaviour {

    public AudioClip[] birds;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!audioSource.isPlaying)
        {
            int n = Random.Range(1, birds.Length);
            audioSource.clip = birds[n];
            audioSource.PlayOneShot(audioSource.clip);

            Debug.Log("birds play");
        }
    }
}
