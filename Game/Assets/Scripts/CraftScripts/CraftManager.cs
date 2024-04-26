using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftManager : MonoBehaviour
{
    public List<CraftableItem> crafts;
    private bool isActivePanel;
    private List<CraftSlot> craftSlots = new List<CraftSlot>();
    private ResultSlot resultSlot;

    void Start()
    {
        transform.gameObject.SetActive(false);
        isActivePanel = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<CraftSlot>() != null)
                craftSlots.Add(transform.GetChild(i).GetComponent<CraftSlot>());
            if (transform.GetChild(i).GetComponent<ResultSlot>() != null)
                resultSlot = transform.GetChild(i).GetComponent<ResultSlot>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCraft()
    {
        var isBreak = false;
        CraftableItem craftableItem = new CraftableItem();
        foreach (CraftableItem craft in crafts)
        {
            foreach (CraftSlot slot in craftSlots)
            {
                if (craft.items.Contains(slot.item))
                {
                    isBreak = false;
                }
                else
                {
                    isBreak = true;
                    break;
                }
            }
            if (!isBreak)
            {
                resultSlot.SetItem(craft);
                foreach (CraftSlot slot in craftSlots)
                {
                    slot.item = null;
                }
                break;
            }
        }
    }
}
