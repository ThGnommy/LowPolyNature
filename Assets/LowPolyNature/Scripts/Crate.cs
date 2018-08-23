using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio.RandomController;

public class Crate : InteractableItemBase {

    private bool mIsOpen = false;
    public AudioRandomController crateOpen;
    public override void OnInteract()
    {
        InteractText = "Press F to ";

        mIsOpen = !mIsOpen;
        InteractText += mIsOpen ? "to close" : "to open";

        GetComponent<Animator>().SetBool("open", mIsOpen);
    }

    public void CrateSound()
    {
        AudioRandomController.Trigger(crateOpen);
    }
}
