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
    public Animator imageAnimator;

    void Start()
    {
        costText.text = item.cost.ToString();
        imageAnimator.SetTrigger(item.name);
    }

    public void OnClick()
    {
        if (Player.getInstance().GetPlayerCurrency() >= item.cost)
        {
            int current = Player.getInstance().RemoveFromPlayerCurrency(item.cost);
            Store.GetInstance().SetCurrencyDisplay(current);

            Player.getInstance().GetPlayerInventory().InsertItem(item);
        }
    }
}
