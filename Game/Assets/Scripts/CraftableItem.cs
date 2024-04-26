using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CraftItem", menuName = "Inventory/New Craft Item")]

public class CraftableItem : ItemScriptableObject
{
    public List<ItemScriptableObject> items;
}
