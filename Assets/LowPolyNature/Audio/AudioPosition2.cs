using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AudioPosition2 : MonoBehaviour
{

    //All our physical needs.
    private AudioSource AudioEmitter;
    private GameObject Character;
    private AudioSource Emitter;
    private AudioListener Listener;
    private BoxCollider AmbientCollider;
    private Vector3 ListenerPosition;

    //all our calculation needs.
    private Vector3 ColliderSizeMax;
    private Vector3 ColliderSizeMin;
    private float emitterX;
    private float emitterY;
    private float emitterZ;

    //Yes or No / True False Values that we need
    private bool IsInArea = false;


    private void Start()
    {
        //find the audio source and define it's location.
        AudioEmitter = GetComponentInChildren<AudioSource>();

        //define where the listener is located.
        Character = GameObject.FindGameObjectWithTag("Player");
        Listener = GameObject.Find("Camera").GetComponent<AudioListener>();

        //define that the collider we want to use is the one on this game object.
        AmbientCollider = GetComponent<BoxCollider>();

        //define the colliders size and it's scale and determine it's border locations.
        ColliderSizeMax = AmbientCollider.transform.position;
        ColliderSizeMin = AmbientCollider.transform.position;
        ColliderSizeMax += (transform.localScale / 2);
        ColliderSizeMin -= (transform.localScale / 2);
    }

    // Update is called once per frame
    void Update()
    {
        ListenerPosition = Listener.transform.position;

        if (ListenerPosition.x > ColliderSizeMin.x && ListenerPosition.x < ColliderSizeMax.x)
        {
            emitterX = ListenerPosition.x;
        }
        if (ListenerPosition.x < ColliderSizeMin.x)
        {
            emitterX = ColliderSizeMin.x;
        }
        if (ListenerPosition.x > ColliderSizeMax.x)
        {
            emitterX = ColliderSizeMax.x;
        }

        if (ListenerPosition.z > ColliderSizeMin.z && ListenerPosition.z < ColliderSizeMax.z)
        {
            emitterZ = ListenerPosition.z;
        }
        if (ListenerPosition.z < ColliderSizeMin.z)
        {
            emitterZ = ColliderSizeMin.z;
        }
        if (ListenerPosition.z > ColliderSizeMax.z)
        {
            emitterZ = ColliderSizeMax.z;
        }

        if (ListenerPosition.y > ColliderSizeMin.y && ListenerPosition.y < ColliderSizeMax.y)
        {
            emitterY = ListenerPosition.y;
        }
        if (ListenerPosition.y < ColliderSizeMin.y)
        {
            emitterY = ColliderSizeMin.y;
        }
        if (ListenerPosition.y > ColliderSizeMax.y)
        {
            emitterY = ColliderSizeMax.y;
        }

        //Debug.Log(ColliderSizeMax);
        //Debug.Log(ColliderSizeMin);
        //Debug.Log(AudioEmitter.transform.position);
        //  Debug.Log(ListenerPosition);
        if (!IsInArea)
        {
            AudioEmitter.transform.position = new Vector3(emitterX, emitterY, emitterZ);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (!IsInArea)
        {
            IsInArea = false;
            Debug.Log("STAY");
        }

        AudioEmitter.transform.position = ListenerPosition;
    }

    private void OnTriggerExit(Collider other)
    {
        IsInArea = false;
        Debug.Log("EXIT");
    }


}