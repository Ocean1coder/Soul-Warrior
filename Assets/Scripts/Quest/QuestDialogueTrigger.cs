using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogueTrigger : DialougeTrigger
{
    [Header("Quest Dialogue Info")]
    public bool isActiveQuest;
    public DialogueQuest[] dialogueQuest;
    public int QuestIndex {get; set;}

    public override void Interact()
    {
        if(isActiveQuest)
        {
            DialogueManager.instance.EnqueueDialogue(dialogueQuest[QuestIndex]);
            QuestManager.instance.CurrentQuestDialogueTrigger = this;
        }
        else
        {
            base.Interact();
        }
    }
    
}
