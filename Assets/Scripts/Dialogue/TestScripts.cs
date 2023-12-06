using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class TestScripts : MonoBehaviour
{
    // public DialogueBase dialogue;
    // public Quest quest;
    public Item item;

    public void TriggerDialogue()
    {
    //    DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            // TriggerDialogue();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryManager.instance.AddItem(item);
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            InventoryManager.instance.RemoveItem(item);
        }
    }

    
    
}
