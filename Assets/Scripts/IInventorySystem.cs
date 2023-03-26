// Written by Eric Tsendjav 03/26/23

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventorySystem
{    
    void SyncInventories();

    void AddItem(InventoryItem anItem, SaveLocation aLocation, bool saveAsJsonFlag = false);

    void RemoveItem(InventoryItem anItem, SaveLocation aLocation);

    //List<InventoryItem> GetInventory(SaveLocation aLocation);
}
