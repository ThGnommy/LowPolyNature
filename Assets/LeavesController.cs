using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio.RandomController;

public class LeavesController : MonoBehaviour {

    public AudioRandomController leavesSound;
    bool canPlay;

    public float time;
	// Use this for initialization
	void Start ()
    {
        canPlay = true;
        StartCoroutine(PlayRandomLeaves());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PlayRandomLeaves()
    {
        while (canPlay)
        {
            AudioRandomController.Trigger(leavesSound);
            yield return new WaitForSeconds(time);
        }
    }
}
