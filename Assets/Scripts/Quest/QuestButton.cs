using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButton : MonoBehaviour
{
    public void Accept()
    {
        QuestManager.instance.CurrentQuestDialogueTrigger.isActiveQuest = false;
        QuestManager.instance.CurrentQuest.InitializeQuest();
        QuestManager.instance.StartQuestBuffer();
        QuestManager.instance.questUI.SetActive(false);

        GameManagerScripts.instance.UpdateTracker($"You've Accept {QuestManager.instance.CurrentQuest.questName}");
    }

    public void Decline()
    {   
        
        QuestManager.instance.StartQuestBuffer();
        QuestManager.instance.questUI.SetActive(false);
    }
}
