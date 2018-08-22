using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio.RandomControllerLPF;

public class FootstepsController : MonoBehaviour {

    public AudioRandomControllerLPF FL_Grass;
    public AudioRandomControllerLPF FR_Grass;
    public AudioRandomControllerLPF FL_Sand;
    public AudioRandomControllerLPF FR_Sand;
    BoxCollider boxCollider;
    RaycastHit hit;
    public float maxDistance = 200;
	
	// Update is called once per frame
	void Update () {

	}

    bool grounded()
    {
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, maxDistance);
    }

    void PlayFootstepsLeft()
    {
        if(grounded())
        {
            if (hit.transform.GetComponent<Collider>().CompareTag("Sand"))
            {
                AudioRandomControllerLPF.Trigger(FL_Sand);
                Debug.Log("play left sand footstep");
            }
            else if (hit.transform.GetComponent<Collider>().CompareTag("Grass"))
            {
                AudioRandomControllerLPF.Trigger(FL_Grass);
                Debug.Log("play left grass footstep");
            }
        }

    }

    void PlayFootstepsRight()
    {
        if (grounded())
        {
            if (hit.transform.GetComponent<Collider>().CompareTag("Sand"))
            {
                AudioRandomControllerLPF.Trigger(FR_Sand);
                Debug.Log("play right sand footstep");
            }
            else if (hit.transform.GetComponent<Collider>().CompareTag("Grass"))
            {
                AudioRandomControllerLPF.Trigger(FR_Grass);
                Debug.Log("play right grass footstep");
            }
        }

    }

}
