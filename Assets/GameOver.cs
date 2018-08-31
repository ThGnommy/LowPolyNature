using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

    public class GameOver : MonoBehaviour
    {

        AudioSource gameOverSound;
        private Animator _animator;
        public GameObject Player;
        bool dead;

        // Use this for initialization
        void Start()
        {
            dead = Player.GetComponent<PlayerController>().IsDead;
            gameOverSound = GetComponent<AudioSource>();
        }

        

        public void PlayerIsDead()
        {
            _animator.SetTrigger("death");
            gameOverSound.Play();
            StartCoroutine(ReloadScene());
        }

        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(2);
            EditorSceneManager.LoadScene("MainMenu");
        }
    }