using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public enum ItemType
    {
        cherry,
        claws,
        armor,
        legs,
        hjboots,
        djboots,
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.cherry:   return ItemAssets.Instance.cherry;
            case ItemType.claws:    return ItemAssets.Instance.claws;
            case ItemType.armor:    return ItemAssets.Instance.armor;
            case ItemType.legs:     return ItemAssets.Instance.legs;
            case ItemType.hjboots:  return ItemAssets.Instance.hjboots;
            case ItemType.djboots:  return ItemAssets.Instance.djboots;
        }
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
}
