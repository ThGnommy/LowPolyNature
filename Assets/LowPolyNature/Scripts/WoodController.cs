using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio.RandomController;

public class WoodController : MonoBehaviour {

    public AudioRandomController woodSound;
    bool canPlay;

    public float time;
    // Use this for initialization
    void Start()
    {
        canPlay = true;
        StartCoroutine(PlayRandomWood());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayRandomWood()
    {
        while (canPlay)
        {
            AudioRandomController.Trigger(woodSound);
            yield return new WaitForSeconds(time);
        }
    }
}
