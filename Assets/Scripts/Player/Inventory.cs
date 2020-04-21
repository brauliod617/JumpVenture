using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public event EventHandler OnItemListChanged;
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

      
        Debug.Log(itemList.Count);
    }


    public void AddItem(Item item)
    {
        if (itemList.Count < 6) { 
            itemList.Add(item);
            OnItemListChanged.Invoke(this, EventArgs.Empty);
        }
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
