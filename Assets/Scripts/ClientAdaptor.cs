// Written by Eric Tsendjav 03/26/23

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientAdaptor : MonoBehaviour
{
    public InventoryItem item;

    private InventorySystem inventorySystem;
    private IInventorySystem inventorySystemAdaptor;

    void Start()
    {
        inventorySystem = new InventorySystem();
        inventorySystemAdaptor = new InventorySystemAdaptor();
    }
    void OnGUI()
    {
        if (GUILayout.Button("Add item (no adaptor)"))
        {
            inventorySystem.AddItem(item);
        }
        if (GUILayout.Button("Add item (with adaptor)"))
        {
            inventorySystemAdaptor.AddItem(item, SaveLocation.Both);
        }
        if (GUILayout.Button("Add item (with adaptor) and save as a JSON file"))
        {
            inventorySystemAdaptor.AddItem(item, SaveLocation.Both, true);
        }
    }
}
