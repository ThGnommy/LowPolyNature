using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class RestartLevel : MonoBehaviour {

    public Animator _animator;
    public GameObject Player;
    bool dead;
    public AudioSource audioSource;
    public AudioMixerSnapshot masterSnap;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.Play();

            _animator.SetTrigger("death");

            masterSnap.TransitionTo(2.5f);

            StartCoroutine(Fading());
        }
    }

    public Image Black;
    public Animator anim;


    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Demo");
    }
}
