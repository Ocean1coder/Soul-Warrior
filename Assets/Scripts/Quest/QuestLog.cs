using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestLog : MonoBehaviour
{
    public static QuestLog instance;

    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDescription;
    public Transform questContent;
    public GameObject questAcceptPrefab;
    public GameObject questLogUI;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI npcTurnInText;
    public Image[] rewardIcons;
    public bool IsQuestLog {get; set;}

    private Quest lastDisplayQuest;

    private void Awake()
    {
        if(instance == null)
        instance = this;
    }

    public void UpdateQuestLogUI(Quest newQuest, string objectiveList)
    {
        lastDisplayQuest = newQuest;

        questName.text = newQuest.questName;
        questDescription.text = newQuest.questDescription;
        npcTurnInText.text ="Turn Into " + newQuest.NPCTurnIs.myName;
        objectiveText.text = objectiveList;

        for(int i = 0; i < rewardIcons.Length; i++)
        {
            try
            {
                rewardIcons[i].gameObject.SetActive(true);
                rewardIcons[i].sprite = newQuest.rewards.itemRewards[i].myIcon;
            }
            catch
            {
                rewardIcons[i].gameObject.SetActive(false);
            }
        }
    }

    public void AddQuestToLog(Quest newQuest)
    {
        var questAccept = Instantiate(questAcceptPrefab, questContent);

        questAccept.GetComponent<QuestAccept>().SetQuest(newQuest);
    }

    // public void AddQuestToLogItem(ItemManager newQuest)
    // {
    //     var questAccept = Instantiate(questAcceptPrefab, questContent);

    //     questAccept.GetComponent<QuestAccept>().SetQuest(newQuest);
    // }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)) 
        {
            questLogUI.SetActive(!questLogUI.activeSelf);
        
            if(questLogUI.activeSelf)
            {   

                IsQuestLog = true;

                try
                {
                    var firstButton = questContent.GetChild(0).GetComponent<Button>();
                    firstButton.Select();   
                    UpdateQuestLogUI(lastDisplayQuest, lastDisplayQuest.GetObjectiveList());

                }
                catch
                {
                    return;
                }
            }
            else
            {
                IsQuestLog = false;
            }
        }
    }
}
