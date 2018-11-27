using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Slot> Items = new List<Slot>();
    [HideInInspector]
    public float TotalWeight;
    public float MaxWeight;
    public bool UpdateUi = false;

    public bool Add(Item item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].item == item)
            {
                if (Items[i].Count < item.MaxStack)
                {
                    if (TotalWeight + item.Weight <= MaxWeight)
                    {
                        Items[i].Count = 1;
                        TotalWeight += item.Weight;
                        UpdateUi = true;
                        return true;
                    }
                }
            }
        }

        if (TotalWeight + item.Weight <= MaxWeight)
        {
            Slot NewSlot = new Slot();
            NewSlot.item = item;
            NewSlot.Count = 1;
            Items.Add(NewSlot);
            TotalWeight += item.Weight;
            UpdateUi = true;
            return true;
        }
        else
        {
            Debug.Log("Item too heavy");
            return false;
        }
    }

    public void Remove(Item item)
    {
        
    }
}

public class Slot
{
    public Item item;
    public int Count;
}