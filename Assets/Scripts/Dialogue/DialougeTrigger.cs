using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : Interactable
{
    [Header("This NPC")]
    public PlayerProfile targetNPC;

    [Header("Dialogue Basic")]
    public DialogueBase[] DB;
    [HideInInspector] public int index;
    public bool nextDialogueOnInteract;

    public bool IsCompleteQuest {get; set;}
    public DialogueBase CompletedQuestDialogue {get; set;}

    public override void Interact()
    {

        if(!DialogueManager.instance.isDialogue)
        {
           if(IsCompleteQuest)
            {
                DialogueManager.instance.EnqueueDialogue(CompletedQuestDialogue);
                DialogueManager.instance.CompletedQuestReady = true;
                IsCompleteQuest = false;
                return;
            }
        }

        if(nextDialogueOnInteract && !DialogueManager.instance.isDialogue)
        {
            if(IsCompleteQuest)
            {
                DialogueManager.instance.EnqueueDialogue(CompletedQuestDialogue);
                IsCompleteQuest = false;
                return;
            }

            DialogueManager.instance.EnqueueDialogue(DB[index]);
            
            if(index < DB.Length -1)
            {
                index++;
            }
        }
        
        else
        {   
            DialogueManager.instance.EnqueueDialogue(DB[index]);
        }
    }

    public void SetIndex(int i)
    {
        index = i;
    }

    // public DialogueBase DB;

    // public override void Interact()
    // {
    //     DialogueManager.instance.EnqueueDialogue(DB);
    // }

    
}
