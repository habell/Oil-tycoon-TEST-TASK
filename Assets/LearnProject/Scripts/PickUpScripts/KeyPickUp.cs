using System.Collections;
using System.Collections.Generic;
using Learning.Scripts.Other;
using UnityEngine;

public class KeyPickUp : PickupItem
{
    [SerializeField] private string _keyName;
    protected override void PickUp(GameObject owner)
    {
        if (owner.TryGetComponent(out InventorySystem inventory))
        {
            inventory.AddNewItem(_keyName);
        }
        else
        {
            Debug.LogError("this entity doesnt have InventorySystem component! Please refactoring this problem!");
            return;
        }
        gameObject.SetActive(false);
    }
}
