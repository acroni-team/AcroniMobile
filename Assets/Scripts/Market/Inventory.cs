using System;
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

    public int DecreseQuantityFromItem(string name)
    {
        int ret = 0;
        foreach(InventoryItem item in inventoryItems)
        {
            if (item.GetName().Equals(name))
            {
                ret = item.DecreaseQuantity();
                
                break;
            }
        }
        return ret;
    }

     public void RemodelList()
     {
        int remodel_index = 0;
        InventoryItem[] model = (InventoryItem[])inventoryItems.Clone();
        inventoryItems = new InventoryItem[4];
        for (int i = 0; i < 4; i++)
        {
            try
            {
                if (model[i].GetQuantity() != 0)
                {
                    //Debug.Log(model[i].GetName() + "; " + model[i].GetQuantity());
                    inventoryItems[remodel_index] = model[i];
                    remodel_index++;
                }
            }catch (Exception)
            {
            }
        }
     }

    public InventoryItem GetItemAt(int index)
    {
        return inventoryItems[index];
    }

    public bool HasItemAt(int index)
    {
        bool r_bool = false;
        try
        {
            inventoryItems[index].GetName();
            r_bool = true;
        } catch (Exception) { }

        return r_bool;
    }
}
