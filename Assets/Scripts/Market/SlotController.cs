using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public Animator imageAnimator;
    public TextMeshProUGUI item_quantity;

    bool isEmpty = true;
    string currentItem;

    public void Fill(string trigger, int quantity)
    {
        imageAnimator.SetTrigger(trigger);
        currentItem = trigger;
        item_quantity.text = quantity.ToString();

        isEmpty = false;
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public bool Equals(InventoryItem item)
    {
        return item.GetName() == currentItem;
    }
}
