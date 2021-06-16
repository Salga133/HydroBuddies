using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType {
        Item1, 
        Item2, 
        Item3, 
        Item4, 
        Item5,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite() 
    {
        switch (itemType) {
            default:
            case ItemType.Item1: return ItemAssets.Instance.swordSprite;
            case ItemType.Item2: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.Item3: return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Item4: return ItemAssets.Instance.coinSprite;
            case ItemType.Item5: return ItemAssets.Instance.medkitSprite;
        }
    }

    public bool IsStackable() 
    {
        switch (itemType) {
            default:
            case ItemType.Item1:
            case ItemType.Item2:
            case ItemType.Item3:
                return true;
            case ItemType.Item4:
            case ItemType.Item5:
                return false;
        }
    }
}
