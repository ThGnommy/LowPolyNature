using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour {

    public Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _animator.SetTrigger("death");

            StartCoroutine(Fading());
        }
    }

    public Image Black;
    public Animator anim;


    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
        SceneManager.LoadScene("Demo");
    }
}
