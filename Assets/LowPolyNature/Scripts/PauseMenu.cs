using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject MainMenu;

    private void Start()
    {
        MainMenu.SetActive(false);
    }

    void Update () {

		if(Input.GetKeyDown(KeyCode.Escape) && !MainMenu.activeInHierarchy)
        {
            MainMenu.SetActive(true);
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        //AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        //AudioListener.pause = false;
    }
}
