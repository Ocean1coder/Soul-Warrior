using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;    

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<Item> inventory = new List<Item>();
    
    public delegate void OnItemAddCallBack(Item item);
    public OnItemAddCallBack onItemAddCallBack;

    public delegate void OnItemRemoveCallBack(Item item);
    public OnItemRemoveCallBack onItemRemoveCallBack;

    public GameObject inventoryUI;
    public Button firstButton;
    public TextMeshProUGUI itemNameTooltip;
    public TextMeshProUGUI itemDescriptionTooltip;

    [HideInInspector] public bool isInventory;
 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void AddItem(Item newItem)
    {
        inventory.Add(newItem);
        if(onItemAddCallBack != null) onItemAddCallBack.Invoke(newItem);
    }

    public void RemoveItem(Item newItem)
    {
        inventory.Remove(newItem);
        if(onItemRemoveCallBack != null) onItemRemoveCallBack.Invoke(newItem);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            
            if(inventoryUI.activeSelf == true)
            {
                firstButton.Select();
                isInventory = true;
            }
            else
            {
                isInventory = false;
            }


        }
    }
}
