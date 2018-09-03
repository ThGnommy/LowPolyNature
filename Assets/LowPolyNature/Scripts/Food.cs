using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio.RandomController;

public class Food : InventoryItemBase
{
    public int FoodPoints = 20;
    public AudioSource pickupLeg;
    public AudioRandomController eatSound;

    public override void OnUse()
    {
        GameManager.Instance.Player.Eat(FoodPoints);

        AudioRandomController.Trigger(eatSound);

        GameManager.Instance.Player.Inventory.RemoveItem(this);

        Destroy(this.gameObject);
    }

    public override void OnPickup()
    {
        base.OnPickup();
        pickupLeg.Play();
    }

}
