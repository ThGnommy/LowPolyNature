using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Audio;

namespace Audio.RandomController
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioRandomController : MonoBehaviour
    {
        AudioSource emitter;
        public AudioClip[] sounds;
        public float minPitch = 0.9f;
        public float maxPitch = 1.1f;

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
            int n = Random.Range(1, sounds.Length);
            emitter.clip = sounds[n];
            emitter.PlayOneShot(emitter.clip);
            
            if(retriggerPrevention)
            {
                sounds[n] = sounds[0];
                sounds[0] = emitter.clip;
            }
        }

        public static void Trigger(AudioRandomController src)
        {
            Debug.Log("The Trigger Was Triggered");
            if (src != null)
            {
                src.PlayRandomSound();
            }
        }

    }
}