using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemCollection : MonoBehaviour
{
    #region Variables

    public List<ItemEnum> itemList = new List<ItemEnum>();
    public enum ItemEnum { Birdcage, Lighter, FireExtinguisher, SprayCan, Phone, FlashLight, Gun, Bullets };

    #endregion

    #region Fields

    #endregion

    public ItemCollection()
    {
    }

    public bool ItemInCollection(ItemEnum itemName)
    {
        return itemList.Contains(itemName);
    }

    public bool CollectItem(ItemEnum itemName)
    {
        if (!ItemInCollection(itemName))
        {
            itemList.Add(itemName);
            return true;
        }
        return false;
    }

    public bool DropItem(ItemEnum itemName)
    {
        if (ItemInCollection(itemName))
        {
            return itemList.Remove(itemName);
        }
        return false;

    }
}
