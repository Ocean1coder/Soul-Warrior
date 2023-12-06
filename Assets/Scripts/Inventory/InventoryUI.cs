using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class InventoryUI : MonoBehaviour
{
    [HideInInspector] public InventorySlot[] slots;

    private void Start()
    {
        slots = GetComponentsInChildren<InventorySlot>();
        InventoryManager.instance.onItemAddCallBack += UpdateInventoryAdd;
        InventoryManager.instance.onItemRemoveCallBack += UpdateInventoryRemove;
    }

    private int? GetNextEmptySlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item == null) return i;
        }

        return null;
    }

    private int? GetSameSlot(Item newItem)
    {
        for(int i = slots.Length - 1; i >= 0; i--)
        {
            if(slots[i].item != null)
            {
                if(slots[i].item == newItem) return i;
            }
        }

        return null;
    }
    public void UpdateInventoryRemove(Item newItem)
    {
        var remainder = GetRemainder(newItem);

        if(remainder == 0)
        {
            remainder = newItem.maxStackSize;
        }
        if(remainder == newItem.maxStackSize)
        {
            slots[(int)GetSameSlot(newItem)].amount.text = "";
            slots[(int)GetSameSlot(newItem)].RemoveItem();
        }
        else
        {
            slots[(int)GetSameSlot(newItem)].amount.text = remainder.ToString();
        }
        // slots[(int)GetSameSlot(newItem)].RemoveItem();
        Debug.Log("We remove an item");
    }

    public void UpdateInventoryAdd(Item newItem)
    {
        var remainder = GetRemainder(newItem);

        if(remainder == 0)
        {
            
            remainder = newItem.maxStackSize;
        }
        if(remainder == 1)
        {
            slots[(int)GetNextEmptySlot()].AddItem(newItem);

            if(newItem is Consumables)
            {
                Consumables consumables = newItem as Consumables;
                
                slots[(int)GetSameSlot(newItem)].GetComponent<UnityItemEventHandler>().unityEvent = consumables.itemEvent;
            }
        }
        else
        {
            slots[(int)GetSameSlot(newItem)].amount.text = remainder.ToString();
            Debug.Log("We add an item");
        }

        // slots[(int)GetNextEmptySlot()].AddItem(newItem);
        
    }

    private int GetRemainder(Item newItem)
    {
        var itemCount = InventoryManager.instance.inventory.Count(x => x == newItem);
        return itemCount % newItem.maxStackSize;
    }
}
