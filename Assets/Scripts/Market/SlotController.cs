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
    public RectTransform rect;
    string slot_item;
    bool isEmpty = true;
    Vector3 startPoint;
    Vector3 offset = new Vector3(0.43f,0.43f);
    [HideInInspector]
    public InventoryItem item_reference;

    //ITEMS
    public GameObject pineCone;
    public GameObject bomba;
    public GameObject trampoline;
    public GameObject timeDecelerator;

    #region SlotController Methods

    public void Fill(InventoryItem slot)
    {
        slot_item = slot.GetName();
        imageAnimator.SetTrigger(slot_item);
        item_quantity.text = slot.GetQuantity().ToString();
        item_reference = slot;

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

    public void Clear()
    {
        imageAnimator.SetTrigger("default");
        item_quantity.text = "0";
        isEmpty = true;
    }

    void SummonItem(string itemName)
    {
        switch(itemName)
        {
            case "Bomba": Instantiate(bomba, transform.position + offset, Quaternion.identity);
                break;
            case "Trampolim": Instantiate(trampoline, transform.position + offset, Quaternion.identity);
                break;
            case "Controlador Temporal": Instantiate(timeDecelerator, transform.position + offset, Quaternion.identity);
                break;
            case "Míssil": Instantiate(pineCone, transform.position + offset, Quaternion.identity);
                break;
        }
        item_quantity.text = Player.getInstance().GetPlayerInventory().DecreseQuantityFromItem(itemName).ToString();
    }
    #endregion

    #region MonoBehaviour Methods

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        if (slotType.Equals(SlotType.CURRENT))
            startPoint = rect.position;
    }

    bool isMoving;
    private void Update()
    {
        if (!slotType.Equals(SlotType.CURRENT))
            return;

        if (item_quantity.text.Equals("0"))
        {
            InventoryController.GetInventoryController().UpdateUI();
            return;
        }

        if (Input.touchCount == 0)
        {
            if (isMoving)
            {
                isMoving = false;
                SummonItem(slot_item);
                rect.anchoredPosition = startPoint;
            }

            isMoving = false;
            return;
        }

        Vector3 position = Input.GetTouch(0).position;
        position = Camera.main.ScreenToWorldPoint(position);

        if (box.OverlapPoint(position) || isMoving)
        {
            isMoving = true;
            Vector3 Position = new Vector3(position.x, position.y, 0);
            //Vector3Int intPosition = new Vector3Int(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), 0);
                rect.position = Position;
        }
    }
    #endregion
}

public enum SlotType
{
    PREVIOUS, CURRENT, NEXT
}