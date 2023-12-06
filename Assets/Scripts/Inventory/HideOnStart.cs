using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    void Start()
    {
        InventoryManager.instance.inventoryUI.SetActive(false);
    }
}
