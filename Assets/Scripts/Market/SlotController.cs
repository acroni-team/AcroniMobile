using System;
using TMPro;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SlotController : MonoBehaviour
{
    //EXTERNAL REFENRENCES
    public Animator imageAnimator;
    public TextMeshProUGUI item_quantity;
    public SlotType slotType;

    //PRIVATE VARIABLES
    BoxCollider2D box;
    string slot_item;
    bool isEmpty = true;
    Vector3 startPoint;
    Vector3 offset = new Vector3(0.43f,0.43f);

    //ITEMS
    public GameObject pineCone;
    public GameObject trampoline;

    #region SlotController Methods

    public void Fill(InventoryItem slot)
    {
        slot_item = slot.GetName();
        imageAnimator.SetTrigger(slot_item);
        item_quantity.text = slot.GetQuantity().ToString();

        isEmpty = false;
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public bool Equals(InventoryItem item)
    {
        return item.GetName() == slot_item;
    }

    public int GetQuantity()
    {
        return Int16.Parse(item_quantity.text);
    }

    void SummonItem(string itemName)
    {
        switch(itemName)
        {
            case "Pinha": Instantiate(pineCone, transform.position + offset, Quaternion.identity);
                break;
            case "Trampolim": Instantiate(trampoline, transform.position + offset, Quaternion.identity);
                break;
        }
        item_quantity.text = Player.getInstance().GetPlayerInventory().DecreseQuantityFromItem(itemName).ToString();
    }

    void ChangeSlotImage()
    {
        imageAnimator.SetTrigger("default");
    }
    #endregion

    #region MonoBehaviour Methods

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        startPoint = transform.position;
    }

    bool isMoving;
    private void Update()
    {
        if (!slotType.Equals(SlotType.CURRENT))
            return;

        if (Input.touchCount == 0)
        {
            if (isMoving)
            {
                SummonItem(slot_item);

                if (item_quantity.text.Equals("0")) /*then*/ ChangeSlotImage();

                transform.position = startPoint;
            }

            isMoving = false;
            return;
        }

        Vector3 position = Input.GetTouch(0).position;
        position = Camera.main.ScreenToWorldPoint(position);

        if (box.OverlapPoint(position) || isMoving)
        {
            isMoving = true;
            Vector3Int intPosition = new Vector3Int(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), 0);
            transform.position = intPosition;
        }
    }
    #endregion
}

public enum SlotType
{
    PREVIOUS, CURRENT, NEXT
}