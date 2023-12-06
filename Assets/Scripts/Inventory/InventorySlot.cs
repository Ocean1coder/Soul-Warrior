using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    [HideInInspector]public Item item;
    public TextMeshProUGUI amount;

    public Button confirmButton;
    public GameObject confirmation;


    public void AddItem(Item newItem)
    {
        icon.overrideSprite = newItem.myIcon;
        item = newItem;
    }

    public void RemoveItem()
    {
        icon.overrideSprite = null;
        item = null;
    }

    public void SelectConfirmButton()
    {
        if( item == null) return;
        

        confirmation.SetActive(true);

        confirmButton.Select();
    }

    public void SelectSameButton()
    {
        GetComponent<Button>().Select();
    }

    public void UseItem()
    {

        InventoryManager.instance.RemoveItem(item);
        
    }
}
