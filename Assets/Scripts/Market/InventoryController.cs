using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using TMPro;


public class InventoryController : MonoBehaviour
{
    static InventoryController inventoryController;
    public Animator imageAnimator;

    public SlotController previous_slot;
    public SlotController current_slot;
    public SlotController next_slot;

    public void AddItem(InventoryItem item)
    {
        if (current_slot.IsEmpty() || current_slot.Equals(item))
        {
            current_slot.Fill(item);
            return;
        }else if (next_slot.IsEmpty() || next_slot.Equals(item))
        {
            next_slot.Fill(item);
            return;
        }else if (previous_slot.IsEmpty() || previous_slot.Equals(item))
        {
            previous_slot.Fill(item);
            return;
        }
    }

    void UpdateUI()
    {
        if(current_slot.GetQuantity() == 0)
        {
            if (next_slot.IsEmpty())
            {
                //current_slot.Fill(next_slot);
            }
        }
    }

    public static InventoryController GetInventoryController()
    {
        return inventoryController;
    }

    void Start()
    {
        inventoryController = this;
    }
}
