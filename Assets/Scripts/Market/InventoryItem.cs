using UnityEngine;
using System.Collections;

public class InventoryItem
{
    StoreItem reference;
    int item_quantity;

    public InventoryItem(StoreItem item, int quantity)
    {
        reference = item;
        item_quantity = quantity;
    }

    public int GetQuantity()
    {
        return item_quantity;
    }

    public void IncrementQuantity()
    {
        item_quantity++;
    }

    public string GetName()
    {
        return reference.name;
    }
}
