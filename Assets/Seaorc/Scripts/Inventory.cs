using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventorySlot> Items = new List<InventorySlot>();
    public float Slots;
    [HideInInspector]
    public float TotalWeight;
    public float MaxWeight;
    public bool UpdateUi = false;

    public bool Add(Item item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if(Items[i].item == item)
            {
                if(Items[i].Count < item.MaxStack)
                {
                    Items[i].Count = 1;
                    UpdateUi = true;
                    return true;
                }
            }
        }

        if(Items.Count < Slots)
        {
            if (TotalWeight + item.Weight <= MaxWeight)
            {
                InventorySlot NewSlot = new InventorySlot();
                NewSlot.item = item;
                NewSlot.Count = 1;
                UpdateUi = true;
                return true;
            }
            else
            {
                Debug.Log("Item too heavy");
                return false;
            }
        }
        else
        {
            Debug.Log("Not enough slots for item");
            return false;
        }
    }

    public void Remove(Item item)
    {
        
    }
}

public class InventorySlot
{
    public Item item;
    public int Count;
}