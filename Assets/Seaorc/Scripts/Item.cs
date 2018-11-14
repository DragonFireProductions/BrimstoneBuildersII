using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string ItemName = "New Item";
    public Sprite Icon;
    public int MaxStack;
    public float Weight;

    public virtual void Use()
    {
        Debug.Log("Used Item: " + ItemName);
    }

}