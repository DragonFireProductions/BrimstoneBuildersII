using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public Image IconImage;

    Slot item;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSlot(Slot _item)
    {
        item = _item;
        NameText.text = item.item.name;
        IconImage.sprite = item.item.Icon;
    }
}
