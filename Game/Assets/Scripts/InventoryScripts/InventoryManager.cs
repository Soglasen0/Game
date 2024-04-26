using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform craftPanel;

    private List<InventorySlot> slots = new List<InventorySlot>();
    private List<CraftSlot> craftSlots = new List<CraftSlot>();
    private InteractiveItem interactiveItem;
    private ResultSlot resultSlot;
    private Camera mainCamera;
    private bool isPressedButton;
    private InventorySlot pressedSlot;

    void Start()
    {
        mainCamera = Camera.main;
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<InventorySlot>() != null)
                slots.Add(transform.GetChild(i).GetComponent<InventorySlot>());
        }

        for(int i = 0; i < craftPanel.childCount; i++)
        {
            if (craftPanel.GetChild(i).GetComponent<CraftSlot>() != null)
                craftSlots.Add(craftPanel.GetChild(i).GetComponent<CraftSlot>());
            if (craftPanel.GetChild(i).GetComponent<ResultSlot>() != null)
                resultSlot = craftPanel.GetChild(i).GetComponent<ResultSlot>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            var collider2D = Physics2D.OverlapPoint(mousePos);
            var itemResource = collider2D?.gameObject.GetComponent<Item>()?.item;

            if (itemResource != null && itemResource.isTakeable)
            {
                AddItem(itemResource);
                Destroy(collider2D.gameObject);
            }

            if (itemResource != null && !itemResource.isTakeable)
            {
                interactiveItem = (InteractiveItem)itemResource;
                if (interactiveItem.item == null)
                {
                    Destroy(collider2D.gameObject);
                }
                if (pressedSlot != null)
                {
                    if (pressedSlot.isActive && pressedSlot.item == interactiveItem.item)
                    {
                        pressedSlot.item = null;
                        Destroy(collider2D.gameObject);
                    }
                }
            }
        }

        if (isPressedButton)
        {

            foreach (var slot in slots)
            {
                slot.isActive = false;
            }
            pressedSlot.isActive = true;
            isPressedButton = false;
        }
    }

    private void AddItem(ItemScriptableObject item)
    {
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.SetItem(item);
                return;
            }
        }
    }

    public void SetActive(InventorySlot inventorySlot)
    {
        if (!craftPanel.gameObject.activeSelf)
        {
            isPressedButton = !inventorySlot.isActive;
            inventorySlot.isActive = !inventorySlot.isActive;
            pressedSlot = inventorySlot;
        }
        else
        {
            foreach(var craftSlot in craftSlots)
            {
                if (craftSlot.item == null)
                {
                    craftSlot.SetItem(inventorySlot.item);
                    inventorySlot.SetEmpty();
                    return;
                }
            }
        }
    }

    public void SetItemToInventory()
    {
        foreach(var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.SetItem(resultSlot.item);
                resultSlot.item = null;
                break;
            }
        }
    }
}
