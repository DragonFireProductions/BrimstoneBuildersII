using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    public Transform InventoryPanal;
    public GameObject SlotPrefab;

    public Inventory CurrentInventory;
    List<InventorySlot> Slots;

    private void Update()
    {
        if (CurrentInventory.UpdateUi)
        {
            if (Slots != null)
                foreach (InventorySlot Slot in Slots)
                {
                    Destroy(Slot.gameObject); 
                }

            Slots = new List<InventorySlot>();

            foreach (Slot item in CurrentInventory.Items)
            {
                InventorySlot slot = Instantiate(SlotPrefab, InventoryPanal).GetComponent<InventorySlot>();
                Slots.Add(slot);
                slot.SetSlot(item);
            }

            CurrentInventory.UpdateUi = false;
        }
    }

    public void SetActiveInventory(Inventory inventory)
    {
        CurrentInventory = inventory;
        CurrentInventory.UpdateUi = true;
    }
}