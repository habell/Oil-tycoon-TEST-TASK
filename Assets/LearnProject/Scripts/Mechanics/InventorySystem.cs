using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private List<string> _playerInventory = new List<string>();

    public void AddNewItem(string itemName)
    {
        _playerInventory.Add(itemName);
    }

    public void RemoveItem(string itemName)
    {
        foreach (var item in _playerInventory)
        {
            if (item == itemName)
            {
                _playerInventory.Remove(item);
                break;
            }
        }
    }
}
