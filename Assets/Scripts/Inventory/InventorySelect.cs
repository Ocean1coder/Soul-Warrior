using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySelect : MonoBehaviour, ISelectHandler
{
    private InventorySlot inventorySlot;

    private void Awake()
    {
        inventorySlot = GetComponent<InventorySlot>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(inventorySlot.item != null)
        {
            InventoryManager.instance.itemNameTooltip.text = inventorySlot.item.myName;
            InventoryManager.instance.itemDescriptionTooltip.text = inventorySlot.item.myDescription;
        }
        else
        {
            InventoryManager.instance.itemNameTooltip.text = "";
            InventoryManager.instance.itemDescriptionTooltip.text = "";
        }
    }

}
