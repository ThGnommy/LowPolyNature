using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LPF.Randomizer
{
    [RequireComponent(typeof(AudioLowPassFilter))]
    [RequireComponent(typeof(AudioSource))]

    public class LowPassRandomizer : MonoBehaviour
    {
        float maxFreq = 22000;
        float minFreq = 10000;

        public void LPFRandomizer()
        {
            GetComponent<AudioLowPassFilter>().cutoffFrequency = Random.Range(minFreq, maxFreq);
        }
    }
}