using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : InventoryItemBase
{
    public int HealthPoints = 20;
    public AudioSource audioSource;
    public AudioSource FirstAidUse;

    private void Start()
    {
       AudioSource audioSource = GetComponent<AudioSource>();
       AudioSource FirstAidUse = GetComponent<AudioSource>();
    }

    public override void OnUse()
    {
        GameManager.Instance.Player.Rehab(HealthPoints);

        GameManager.Instance.Player.Inventory.RemoveItem(this);

        FirstAidUse.Play();

        Destroy(this.gameObject);
    }

    public override void OnPickup()
    {
        base.OnPickup();
        audioSource.Play();
    }
}
