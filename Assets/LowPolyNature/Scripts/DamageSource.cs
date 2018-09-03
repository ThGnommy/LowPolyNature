using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DamageSource : MonoBehaviour {

    #region Private members

    private bool _isCausingDamage = false;

    #endregion

    #region Public Members

    public float DamageRepeatRate = 0.1f;

    public int DamageAmount = 1;

    public bool Repeating = true;

    public AudioMixerSnapshot onDamage;

    public AudioMixerSnapshot safe;


    #endregion

    private void OnTriggerEnter(Collider other)
    {
        _isCausingDamage = true;

        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if(player != null)
        {
            if (Repeating)
            {
                // Repeating damage
                StartCoroutine(TakeDamage(player, DamageRepeatRate));
            }
            else
            {
                // Just one time damage
                player.TakeDamage(DamageAmount);
            }
        }

        onDamage.TransitionTo(.5f);
    }

    IEnumerator TakeDamage(PlayerController player, float repeatRate)
    {
        while (_isCausingDamage)
        {
            player.TakeDamage(DamageAmount);
            TakeDamage(player, repeatRate);

            if (player.IsDead)
                _isCausingDamage = false;

            yield return new WaitForSeconds(repeatRate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            _isCausingDamage = false;

            safe.TransitionTo(.5f);
        }
    }
}
