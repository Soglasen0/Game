using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSlot : MonoBehaviour
{
    public ItemScriptableObject item;
    public bool isEmpty;
    public bool isActive;
    private GameObject icon;

    void Start()
    {
        icon = transform.GetChild(0).gameObject;
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
            icon.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            icon.GetComponent<Image>().sprite = null;
        }
    }

    public void SetItem(CraftableItem item)
    {
        this.item = item;
        isEmpty = false;
        isActive = true;
        icon.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        icon.GetComponent<Image>().sprite = item.icon;
    }
}
