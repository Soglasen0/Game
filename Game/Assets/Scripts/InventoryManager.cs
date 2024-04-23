using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<InventorySlot> slots = new List<InventorySlot>();
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<InventorySlot>() != null)
                slots.Add(transform.GetChild(i).GetComponent<InventorySlot>());
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
        }
    }

    private void AddItem(ItemScriptableObject item)
    {
        foreach (InventorySlot slot in slots)
        {
            if (!slot.isEmpty)
            {
                slot.SetItem(item);
                return;
            }
        }
    }
}
