// Written by Eric Tsendjav 03/26/23

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem
{
    public void AddItem(InventoryItem anItem)
    {
        Debug.Log("Adding item to the cloud");
    }
    public void RemoveItem(InventoryItem anItem)
    {
        Debug.Log("Removing item from the cloud");
    }
    public List<InventoryItem> GetInventory()
    {
        Debug.Log("Getting items from the cloud");
        return new List<InventoryItem>();
    }
}
