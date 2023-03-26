// Written by Eric Tsendjav 03/26/23

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory")]

public class InventoryItem : ScriptableObject
{
    // placeholder class you will need to flesh this out for your assignment
    // you can change it to a monster, or npc, or anything in you game you want
    // to save, e.g.
    
    public int id;
    public string description;

    public int Id
    {
        get => id;
        set => id = value;
    }
    
    public string Description
    {
        get => description;
        set => description = value;
    }

    public InventoryItemToJsonData ToJsonData()
    {
        return new InventoryItemToJsonData
        {
            Id = id,
            Description = description
        };
    }
}