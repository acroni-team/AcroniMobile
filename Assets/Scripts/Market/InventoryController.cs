﻿using UnityEngine;
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

    public void UpdateUI()
    {
        if(current_slot.GetQuantity() == 0)
        {
            if (!next_slot.IsEmpty())
            {
                current_slot.Fill(next_slot.item_reference);

                if(!previous_slot.IsEmpty())
                {
                    next_slot.Fill(previous_slot.item_reference);
                    
                    if (Player.getInstance().GetPlayerInventory().HasItemAt(3))
                    {
                        previous_slot.Fill(Player.getInstance().GetPlayerInventory().GetItemAt(3));
                        Player.getInstance().GetPlayerInventory().RemodelList();
                    }
                    else
                        previous_slot.Clear();
                }
                else
                    next_slot.Clear();
            }
            else
                current_slot.Clear();
        }
    }

    public static InventoryController GetInventoryController()
    {
        return inventoryController;
    }

    Vector3 lastPosition = new Vector3(0,0,0);
    private void Update()
    {
        if (!interactible)
            return;

        if (Input.touchCount == 0)
            return;

        Vector3 inputPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        if (GetComponent<BoxCollider2D>().OverlapPoint(inputPosition))
        {
            //Debug.Log(lastPosition.x > inputPosition.x);

            if (Input.GetTouch(0).phase.Equals(TouchPhase.Moved))
                lastPosition = inputPosition;
        }
    }

    bool interactible;
    public void SetInteractible(bool interacbility)
    {
        interactible = interacbility;
        current_slot.SetEnabled(interacbility);
    }

    void Start()
    {
        inventoryController = this;
    }
}
