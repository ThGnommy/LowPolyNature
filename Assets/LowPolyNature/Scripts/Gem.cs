using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : InventoryItemBase {

    public AudioSource gemsound;
    public override void OnUse()
    {
        // TODO: Do something with the object.... next tutorial!
        base.OnUse();
    }

    public override void OnPickup()
    {
        base.OnPickup();
        gemsound.GetComponent<AudioSource>().Play();
    }
}
