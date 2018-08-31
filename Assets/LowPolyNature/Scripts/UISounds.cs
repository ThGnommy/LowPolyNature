using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISounds : MonoBehaviour {

    public AudioClip ui_Select;
    public AudioClip ui_Mouseover;
    public AudioClip ui_Undo;
    AudioSource audioSource;
    public Button PlayButton;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    public void PlaySelect()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(ui_Select);
    }

    public void MuteAudioSource()
    {
        StartCoroutine(DisableAudioSource());
    }

    public void PlayMouseover()
    {
        audioSource.PlayOneShot(ui_Mouseover);
    }

    public void PlayUndo()
    {
        audioSource.PlayOneShot(ui_Undo);

    }

    IEnumerator DisableAudioSource()
    {
        yield return new WaitForSeconds(.56f);
        audioSource.mute = true;
    }
}
