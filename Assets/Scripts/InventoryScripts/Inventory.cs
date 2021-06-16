using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    public List<Item> itemList = new List<Item>();

    public Inventory() 
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Item1, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Item2, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Item3, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Item4, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Item3, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Item4, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Item4, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Item4, amount = 1 });
    }

    public void AddItem(Item item) 
    {
        if (item.IsStackable()) {
            // Debug.Log(item.itemType);
            bool itemAlreadyInInventory = false;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item) 
    {
        Vector2 garbageBinPos = GameObject.Find("GarbageBin").GetComponent<RectTransform>().anchoredPosition;
        Vector2 playerPos = GameObject.Find("Player 03").transform.position;
        float distance = Vector2.Distance(playerPos, garbageBinPos);
        Debug.Log(distance);
        if (distance > 3) return;
        if (item.IsStackable()) {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                itemList.Remove(itemInInventory);
            }
        } else {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item) {
        BasicMovement playerMovement = GameObject.Find("Player 03").GetComponent<BasicMovement>();

        if (item.itemType == Item.ItemType.Item2) {
            playerMovement.AddHealth(10);
            
        }

    }

    public List<Item> GetItemList() 
    {
        
        return itemList;
    }

    public int inventoryList 
    {
        get => itemList.Count;
    }
}