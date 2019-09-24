using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryController : MonoBehaviour
{
    static InventoryController inventoryController;

    public Image firstSlot;
    public Animator f_Animator;
    [HideInInspector]
    public StoreItem storeItem1;

    public Image secondSlot;
    public Animator s_Animator;
    [HideInInspector]
    public StoreItem storeItem2;

    bool firstTime = true;
    [HideInInspector]
    public bool canCheck = false;
    public void AddItem(StoreItem reference, int quantity)
    {
        if (firstTime || storeItem1.name.Equals(reference.name))
        {
            firstSlot.sprite = reference.image;
            f_Animator.SetTrigger(reference.name);
            firstSlot.GetComponentInChildren<TextMeshProUGUI>().text = quantity.ToString();
            firstTime = false;
            storeItem1 = reference;
        }else
        {
            secondSlot.sprite = reference.image;
            s_Animator.SetTrigger(reference.name);
            secondSlot.GetComponentInChildren<TextMeshProUGUI>().text = quantity.ToString();
            storeItem2 = reference;
            canCheck = true;
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
