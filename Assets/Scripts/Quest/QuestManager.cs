using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    #region Quest Singleton

    public static QuestManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public GameObject questUI;
    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDescription;
    public Button questAcceptButton;
    public Button questDeclineButton;
    
    public bool isQuestUI {get; set;}
    public QuestDialogueTrigger CurrentQuestDialogueTrigger {get; set;}
    public Quest CurrentQuest {get; set;}

    public void SetQuestUI(Quest newQuest)
    {
        CurrentQuest = newQuest;
        questUI.SetActive(true);
        questName.text = newQuest.questName;
        questDescription.text = newQuest.questDescription;
        questAcceptButton.Select();
        questDeclineButton.Select();
    }

    public void StartQuestBuffer()
    {
        StartCoroutine(QuestBuffer());
    }

    private IEnumerator QuestBuffer()
    {
        yield return new WaitForSeconds(0.1f);
        isQuestUI = false;
    }

}
