using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public StoreItem item;

    public TextMeshProUGUI costText;
    public Image imageItem;

    void Start()
    {
        costText.text = item.cost.ToString();
        imageItem.sprite = item.image;
    }

    public void OnClick()
    {
        if (InventoryController.GetInventoryController().canCheck)
            if (!InventoryController.GetInventoryController().storeItem1.name.Equals(item.name) && !InventoryController.GetInventoryController().storeItem2.name.Equals(item.name))
                return;

        int current = Player.getInstance().RemoveFromPlayerCurrency(item.cost);
        Store.GetInstance().SetCurrencyDisplay(current);

        if (current >= 0)
            Player.getInstance().GetPlayerInventory().InsertItem(item);
    }
}
