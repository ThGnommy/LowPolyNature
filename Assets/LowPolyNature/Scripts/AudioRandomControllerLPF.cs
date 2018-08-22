using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;

namespace Audio.RandomControllerLPF
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(AudioLowPassFilter))]
    public class AudioRandomControllerLPF : MonoBehaviour
    {
        AudioSource emitter;
        public float minVol = 0.7f;
        public float maxVol = 1;
        public AudioClip[] sounds;
        public float minPitch = 0.9f;
        public float maxPitch = 1.1f;
        float maxFreq = 20000;
        float minFreq = 17500;
        public bool retriggerPrevention = true;

        // Use this for initialization
        void Start()
        {
            emitter = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayRandomSound()
        {
            float pitch = Random.Range(minPitch, maxPitch);
            emitter.pitch = pitch;
            GetComponent<AudioLowPassFilter>().cutoffFrequency = Random.Range(minFreq, maxFreq);
            float volume = Random.Range(minVol, maxVol);
            emitter.volume = volume;
            int n = Random.Range(1, sounds.Length);
            emitter.clip = sounds[n];
            emitter.PlayOneShot(emitter.clip);
            
            if(retriggerPrevention)
            {
                sounds[n] = sounds[0];
                sounds[0] = emitter.clip;
            }
        }

        public static void Trigger(AudioRandomControllerLPF src)
        {
            Debug.Log("The Trigger Was Triggered");
            if (src != null)
            {
                src.PlayRandomSound();
            }
        }
    }
}