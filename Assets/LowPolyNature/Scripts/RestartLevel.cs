using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class RestartLevel : MonoBehaviour {

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EditorSceneManager.LoadScene("Demo");
        }
    }
}
