using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ScatterAudioEvent : MonoBehaviour {

    public AudioClip[] sounds;
    AudioSource emitter;

    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;
    public float minVol = 0.7f;
    public float maxVol = 1;
    public bool retriggerPrevention = true;

    public float minSec = 3;
    public float maxSec = 8;

    bool isDead;

    // Use this for initialization
    void Start ()
    {
        emitter = GetComponent<AudioSource>();
        StartCoroutine(ScatterRoutine());
    }

    // Update is called once per frame
    void Update ()
    {
    }

    IEnumerator ScatterRoutine()
    {
        float randomSec = Random.Range(minSec, maxSec);
        while (true)
        {
            //Debug.Log(Time.time);
            yield return new WaitForSeconds(randomSec);
            PlayRandomSound();
            //Debug.Log(Time.time);
        }
    }

    public void PlayRandomSound()
    {
        float pitch = Random.Range(minPitch, maxPitch);
        emitter.pitch = pitch;
        float volume = Random.Range(minVol, maxVol);
        emitter.volume = volume;
        int n = Random.Range(1, sounds.Length);
        emitter.clip = sounds[n];
        emitter.PlayOneShot(emitter.clip);

        if (retriggerPrevention)
        {
            sounds[n] = sounds[0];
            sounds[0] = emitter.clip;
        }
    }
}
