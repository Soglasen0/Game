using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public bool isEmpty;
    public bool isActive;
    private GameObject icon;

    void Start()
    {
        icon = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItem(ItemScriptableObject item)
    {
        this.item = item;
        isEmpty = false;
        icon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        icon.GetComponent<Image>().sprite = item.icon;
    }

    public void SetActive() 
    {
        isActive = true;
    }
}
