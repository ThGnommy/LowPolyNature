using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class AudioPosition : MonoBehaviour {

    AudioSource AudioEmitter;
    Vector3 EmitterPosition;
    GameObject Character;
    AudioListener Listener;
    BoxCollider AmbienceCollider;
    Vector3 ListenerPosition;

    Vector3 ColliderSizeMin;
    Vector3 ColliderSizeMax;

    float emitterX;
    float emitterY;
    float emitterZ;

    bool IsInArea = false;

	// Use this for initialization
	void Start ()
    {
        AudioEmitter = GetComponentInChildren<AudioSource>();
        //EmitterPosition = AudioEmitter.transform.position;
        Character = GameObject.Find("lp_guy");
        Listener = GameObject.Find("Camera").GetComponent<AudioListener>();
        AmbienceCollider = GetComponent<BoxCollider>();

        ColliderSizeMax = AmbienceCollider.transform.position;
        ColliderSizeMin = AmbienceCollider.transform.position;

        ColliderSizeMax += (transform.localScale / 2);
        ColliderSizeMin -= (transform.localScale / 2);
    }

    // Update is called once per frame
    void Update ()
    {
        // X

        if (ListenerPosition.x > ColliderSizeMin.x && ListenerPosition.x < ColliderSizeMax.x)
        {
            emitterX = ListenerPosition.x;
        }

        if (ListenerPosition.x < ColliderSizeMin.x)
        {
            emitterX = ColliderSizeMax.x;
        }

        if (ListenerPosition.x > ColliderSizeMax.x)
        {
            emitterX = ColliderSizeMax.x;
        }

        // Y

        if (ListenerPosition.y > ColliderSizeMin.y && ListenerPosition.y < ColliderSizeMax.y)
        {
            emitterY = ListenerPosition.y;
        }

        if (ListenerPosition.y < ColliderSizeMin.y)
        {
            emitterY = ColliderSizeMax.y;
        }

        if (ListenerPosition.y > ColliderSizeMax.y)
        {
            emitterY = ColliderSizeMax.y;
        }

        // Z

        if (ListenerPosition.z > ColliderSizeMin.z && ListenerPosition.z < ColliderSizeMax.z)
        {
            emitterZ = ListenerPosition.z;
        }

        if (ListenerPosition.z < ColliderSizeMin.z)
        {
            emitterZ = ColliderSizeMax.z;
        }

        if (ListenerPosition.z > ColliderSizeMax.z)
        {
            emitterZ = ColliderSizeMax.z;
        }

        if (!IsInArea)
        {
            AudioEmitter.transform.position = new Vector3(emitterX, emitterY, emitterZ);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsInArea)
        {
            IsInArea = true;
            AudioEmitter.transform.position = ListenerPosition;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        IsInArea = false;
    }
}
