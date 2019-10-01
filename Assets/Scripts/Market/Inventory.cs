using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    InventoryItem[] inventoryItems;

    public Inventory()
    {
        inventoryItems = new InventoryItem[4];
    }

    public int prov = 0;
    bool canExecute = true;
    public void InsertItem(StoreItem item)
    {
        if (!canExecute)
            return;

        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null)
            {
                inventoryItems[i] = new InventoryItem(item, 1);
                InventoryController.GetInventoryController().AddItem(inventoryItems[i]);
                prov++;
                break;
            }
            else if (inventoryItems[i].GetName().Equals(item.name))
            {
                inventoryItems[i].IncrementQuantity();
                InventoryController.GetInventoryController().AddItem(inventoryItems[i]);
                break;
            }
        }

        if (Player.getInstance().GetPlayerCurrency() == 0)
            canExecute = false;
        //Código de teste para a loja (Use Control + Shift + C enquanto roda)
        //string retur = "List: \n";
        //for (int inv = 0; inv < prov; inv++)
        //{
        //    retur += inventoryItems[inv].GetName() + ": " + inventoryItems[inv].GetQuantity() + "\n";
        //}
        //Debug.Log(retur);
    }
}
