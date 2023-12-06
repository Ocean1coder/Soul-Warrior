using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardManager : MonoBehaviour
{
    public TextMeshProUGUI questName;
    public Image[] questRewardsIcons;
    public GameObject questRewardUI;
    public Quest testQuest;
    public Button claimButton;
    public bool IsQuestReward { get; set; }
   
    public void SetRewardUI(Quest quest)
    {
        IsQuestReward = true;

        questRewardUI.SetActive(true);

        claimButton.Select();

        questName.text = quest.questName;

        for(int i = 0; i < quest.rewards.itemRewards.Length; i++)
        {
            questRewardsIcons[i].gameObject.SetActive(true);
            questRewardsIcons[i].sprite = quest.rewards.itemRewards[i].myIcon;
        }
    }

    public void Claim()
    {

        Quest currentQuest = DialogueManager.instance.CompletedQuest;

        for(int i = 0; i < currentQuest.rewards.itemRewards.Length; i++)
        {
            InventoryManager.instance.AddItem(currentQuest.rewards.itemRewards[i]);
            
        }

        questRewardUI.SetActive(false);

        for(int i = 0; i < questRewardsIcons.Length; i++)
        {
            questRewardsIcons[i].gameObject.SetActive(true);
            
        }

        StartCoroutine(QuestRewardBuffer());
    }

    IEnumerator QuestRewardBuffer()
    {
        yield return new WaitForSeconds(0.1f);
        IsQuestReward = false;
    }
}
