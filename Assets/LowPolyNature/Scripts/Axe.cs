using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : InventoryItemBase {

    AudioSource audioSource;

    

    public override void OnUse()
    {
        base.OnUse();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
