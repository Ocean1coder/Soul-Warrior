using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject
{
    public string questName;
    [TextArea(5, 10)]
    public string questDescription;

    public int[] CrurrentAmount {get; set;}
    public int[] RequiredAmount {get; set;}

    public bool IsCompleted {get; set;}

    public PlayerProfile NPCTurnIs;
    public DialogueBase CompletedQuestDialogue;

    [System.Serializable]
    public class Rewards
    {
        public Item[] itemRewards;
    }
    
    public Rewards rewards;
    

    public virtual void InitializeQuest()
    {
        IsCompleted = false;
        CrurrentAmount = new int[RequiredAmount.Length];
        QuestLog.instance.AddQuestToLog(this);
    }

    public void Evaluate()
    {
        for(int i = 0; i < RequiredAmount.Length; i++)
        {
            if(CrurrentAmount[i] < RequiredAmount[i])
            {
                return;
            }
           
        }

        Debug.Log("Quest is Complete");

        for(int i = 0; i < GameManagerScripts.instance.allDialogueTriggers.Length; i++)
        {
            if(GameManagerScripts.instance.allDialogueTriggers[i].targetNPC == NPCTurnIs)
            {
                GameManagerScripts.instance.allDialogueTriggers[i].IsCompleteQuest = true;
                GameManagerScripts.instance.allDialogueTriggers[i].CompletedQuestDialogue = CompletedQuestDialogue;
                Debug.Log("Me Found " + NPCTurnIs);
                break;
            }
        }

        IsCompleted = true;
        DialogueManager.instance.CompletedQuest = this;

    }

    public virtual string GetObjectiveList()
    {
        return null;
    }
}
