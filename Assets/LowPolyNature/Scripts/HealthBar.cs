using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class HealthBar : MonoBehaviour {

    public Image ImgHealthBar;

    public Text TxtHealth;

    public int Min;

    public int Max;

    private int mCurrentValue;

    private float mCurrentPercent;

    // Audio public

    public AudioClip Clip1;
    public AudioSource s_FullFood;
    public AudioSource s_HalfFood;

    public AudioMixerSnapshot FullFoodSnap;
    public AudioMixerSnapshot HalfFoodSnap;
    
    public void SetValue(int health)
    {
        if(health != mCurrentValue)
        {
            if(Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            TxtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent * 100));

            ImgHealthBar.fillAmount = mCurrentPercent;
        }
    }

    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public int CurrentValue
    {
        get { return mCurrentValue;  }
    }

	// Use this for initialization
	void Start ()
    {

    }

    /*private void FixedUpdate()
    {
        if(CurrentValue > 50)
        {
            StartMusicSnap.TransitionTo(3);

            if (!s_StartMusic.isPlaying)
            {
                s_StartMusic.PlayOneShot(Clip1);
                s_HalfFood.PlayOneShot(Clip2);
                print("100");
            }

        }

        if(CurrentValue < 50)
        {
            HalfFoodSnap.TransitionTo(3);
            print("50");
        }

    }*/

}
