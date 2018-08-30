using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : InventoryItemBase
{
    public int HealthPoints = 20;
    public AudioSource audioSource;

    private void Start()
    {
       AudioSource audioSource = GetComponent<AudioSource>();
    }

    public override void OnUse()
    {
        GameManager.Instance.Player.Rehab(HealthPoints);

        GameManager.Instance.Player.Inventory.RemoveItem(this);

        Destroy(this.gameObject);
    }

    public override void OnPickup()
    {
        base.OnPickup();
        audioSource.Play();
    }
}
