using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistance : MonoBehaviour {

    float distance;
    private GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        distance = this.gameObject.transform.position.magnitude - Player.transform.position.magnitude;
        Debug.Log(distance);
	}
}
