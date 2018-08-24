using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MusicController : MonoBehaviour {

    public AudioSource MainMusic;
    public AudioSource HalfFood;
    public GameObject FoodBar;
    public AudioMixerSnapshot StartSnapshot;
    public AudioMixerSnapshot HalfFoodSnapshot;
    HealthBar mFoodBar;

    // Use this for initialization
    void Start ()
    {
        mFoodBar = GetComponent<HealthBar>();
        StartSnapshot.TransitionTo(0);
    }

    void FixedUpdate ()
    {
        if(mFoodBar.CurrentValue == 1)
        {
            Debug.Log("FUNZIONA PIDDI");
            MainMusic.Play();
        }
    }
}
