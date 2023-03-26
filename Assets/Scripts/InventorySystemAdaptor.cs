// Written by Eric (Erdenesukh) Tsendjav
// 03/23/2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class InventorySystemAdaptor : InventorySystem, IInventorySystem
{
    private List<InventoryItem> cloudInventory;

    public bool saveAsJson = false;

    // Had to change the directory to save the inventory to a subdirectory within the C drive. 
    // WARNING!!!!! Please make sure this folder exists before running the game/application and saving!!!
    private string directoryToSaveInventory = "C:/myItems";
    private string csvSaveDirectory => Path.Combine(directoryToSaveInventory, "Inventory.csv");
    private string jsonSaveDirectory => Path.Combine(directoryToSaveInventory, "Inventory.json");
    
    public void SyncInventories()
    {
        var cloudInventory = GetInventory();
        Debug.Log("Downloading the cloud inventroy");
    }

    // Using a default variable to switch between Json and CSV files
    
    public void AddItem(InventoryItem anItem, SaveLocation aLocation, bool saveAsJsonFlag = false)
    {
        saveAsJson = saveAsJsonFlag;
        
        if (aLocation == SaveLocation.Cloud)
        {
            AddItem(anItem);
        }
        if (aLocation == SaveLocation.Local)
        {
            SaveToLocal(anItem);
        }
        if (aLocation == SaveLocation.Both)
        {
            SaveToLocal(anItem);
        }
    }

    public void RemoveItem(InventoryItem anItem, SaveLocation aLocation)
    {
        if (aLocation == SaveLocation.Cloud)
        {
            RemoveItem(anItem);
        }
        if (aLocation == SaveLocation.Local)
        {
            Debug.Log("We need code here to remove to the local drive");
        }
        if (aLocation == SaveLocation.Both)
        {
            RemoveItem(anItem);
            Debug.Log("We need code here to remove to the local drive");
        }
    }

    private void SaveToLocal(InventoryItem item)
    {
        if (saveAsJson)
        {
            SaveAsJson(item);
        }
        else
        {
            SaveAsCsv(item);
        }
    }

    // serialize the item to a JSON file using a custom class and a wrapper class
    private void SaveAsJson(InventoryItem item)
    {
        InventoryItemToJsonData jsonData = item.ToJsonData();
        List<InventoryItemToJsonData> myListOfJsonItems =new List<InventoryItemToJsonData>() { jsonData };
        string json = JsonUtility.ToJson(new InventoryItemsWrapper { items = myListOfJsonItems }, true);
        File.WriteAllText(jsonSaveDirectory, json);
    }
    
    // using a stringbuilder object to write the inventory items which will always be the item passed in
    private void SaveAsCsv(InventoryItem item)
    {
        List<InventoryItem> items = new List<InventoryItem>();
        items.Add(item);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("ID,Definition");

        foreach (var i in items)
        {
            sb.AppendLine($"{i.Id},{i.Description}");
        }

        File.WriteAllText(csvSaveDirectory, sb.ToString());
    }
    
    // wrapper class necessary to write to the json file
    [System.Serializable]
    public class InventoryItemsWrapper
    {
        public List<InventoryItemToJsonData> items;
    }

}