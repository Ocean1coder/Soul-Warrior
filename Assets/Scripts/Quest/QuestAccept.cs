using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestAccept : MonoBehaviour
{
    [HideInInspector] public Quest myQuest;

    // [HideInInspector] public ItemManager myQuestA;

    public TextMeshProUGUI questNameText;
    public Sprite checkedBox;
    public Image unCheckBox;

    public void SetQuest(Quest newQuest)
    {
        myQuest = newQuest;
        questNameText.text = newQuest.questName; 
    }
    
    // public void SetQuest(ItemReward newQuest)
    // {
    //     myQuestA = newQuest;
    //     questNameText.text = newQuest.questName; 
    // }

    public void OnPressed()
    {
        QuestLog.instance.UpdateQuestLogUI(myQuest, myQuest.GetObjectiveList());
    }

    private void OnEnable()
    {
        if(myQuest.IsCompleted)
        {
            unCheckBox.sprite = checkedBox;
        }
    }
}
