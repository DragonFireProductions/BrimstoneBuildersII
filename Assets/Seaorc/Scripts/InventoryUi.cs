using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    Inventory CurrentInventory;

    private void Update()
    {
        if (CurrentInventory.UpdateUi)
        {

        }
    }

    public void SetActiveInventory(Inventory inventory)
    {
        CurrentInventory = inventory;
        CurrentInventory.UpdateUi = true;
    }
}