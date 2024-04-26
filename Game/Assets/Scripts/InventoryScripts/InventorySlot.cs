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
    private GameObject background;
    private Color colorGray;
    private Color colorActiveGray;

    void Start()
    {
        icon = transform.GetChild(0).gameObject;
        background = transform.GetComponent<Image>().gameObject;
        colorGray = new Color(0.631f, 0.616f, 0.616f, 1f);
        colorActiveGray = new Color(0.706f, 0.706f, 0.706f, 1f);
        if (item == null)
        {
            isEmpty = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (item == null)
        {
            isEmpty = true;
            isActive = false;
            background.GetComponent<Image>().color = colorGray;
            icon.GetComponent<Image>().color = new Color(0, 0, 0, 0f);
            icon.GetComponent<Image>().sprite = null;
        }
        else
        {
            isEmpty = false;
            icon.GetComponent<Image>().color = new Color(1, 1, 1);
            icon.GetComponent<Image>().sprite = item.icon;
        }
        if (isActive)
            background.GetComponent<Image>().color = colorActiveGray;
        else
            background.GetComponent<Image>().color = colorGray;
    }

    public void SetItem(ItemScriptableObject item)
    {
        this.item = item;
        isEmpty = false;
        isActive = false;
        background.GetComponent<Image>().color = colorGray;
        icon.GetComponent<Image>().color = new Color(1, 1, 1);
        icon.GetComponent<Image>().sprite = item.icon;
    }

    public void SetEmpty()
    {
        this.item = null;
        isEmpty = true;
        isActive = false;
        background.GetComponent<Image>().color = colorGray;
        icon.GetComponent<Image>().sprite = null;
    }
}