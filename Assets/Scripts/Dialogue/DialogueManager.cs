using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("fix this " + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject dialogueBox;

    public TextMeshProUGUI dialogueName;
    public TextMeshProUGUI dialogueText;
    public float delay = 0.001f;

    public Queue<DialogueBase.Info> dialogueInfo;

    private bool isDialogueOption;
    public GameObject dialogueOptionUI;
    public bool isDialogue;
    public GameObject[] optionButtons;
    private int optionsAmount;
    public TextMeshProUGUI questionText;

    private DialogueBase currentDialogue;
    private bool isCurrentLyTyping;
    private string completeText;
    private bool buffer;

    public delegate void OnDialogueLineCallBack(int dialogueLine);
    public OnDialogueLineCallBack onDialogueLineCallBack;
    private int totalLineCount;
    
    public Quest CompletedQuest {get; set;}

    // public ItemManager CompletedQuestItem {get; set;}


    public bool CompletedQuestReady {get; set;}

    private void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();
    }

    public void EnqueueDialogue(DialogueBase db)
    {
        //if (isDialogue || QuestManager.instance.isQuestUI || GameManagerScripts.instance.rewardManager.isQuestReward || QuestLog.instance.IsQuestLog) return;
        if(isDialogue || QuestManager.instance.isQuestUI || GameManagerScripts.instance.rewardManager.IsQuestReward || QuestLog.instance.IsQuestLog ) return;
        buffer = true;
        isDialogue = true;
        StartCoroutine(BufferTimer());

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();
        currentDialogue = db;

        OptionsParser(db); 

        foreach(DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        totalLineCount = dialogueInfo.Count;

        DequeueDialogue();

    }

    public void DequeueDialogue()
    {
        if(isCurrentLyTyping == true)
        {
            if(buffer == true) return;
            CompleteText();
            StopAllCoroutines();
            isCurrentLyTyping = false;
            return;
        }

        if(dialogueInfo.Count == 0)
        {   
            EndofDialogue();
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();

        if (onDialogueLineCallBack != null)
        {
            onDialogueLineCallBack.Invoke(totalLineCount - dialogueInfo.Count);
        }

        completeText = info.myText;
        dialogueName.text = info.player.myName;
        dialogueText.text = info.myText;
        

        dialogueText.text = "";
        StartCoroutine(TypeText(info));

    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        isCurrentLyTyping = true;
        
        foreach(char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            
        }
        FinishTalking();
        isCurrentLyTyping = false;
    }

    IEnumerator BufferTimer()
    {
        yield return new WaitForSeconds(0.1f);
        buffer = false;
    }

    private void CompleteText()
    {
        FinishTalking();
        dialogueText.text = completeText;
    }

    private void FinishTalking()
    {

    }

    public void EndofDialogue()
    {
        dialogueBox.SetActive(false);   
        OptionsLogic();
        CheckIfDialogueQuest();
        SetItemRewards();
    }

    private void SetItemRewards()
    {
        if(CompletedQuestReady)
        {
            GameManagerScripts.instance.rewardManager.SetRewardUI(CompletedQuest);

            CompletedQuestReady = false;
        }
    }

    private void CheckIfDialogueQuest()
    {
        if(currentDialogue is DialogueQuest)
        {
            DialogueQuest DQ = currentDialogue as DialogueQuest;
            QuestManager.instance.SetQuestUI(DQ.quest);
        }
    }

    private void OptionsLogic()
    {
        if(isDialogueOption == true)
        {
            dialogueOptionUI.SetActive(true);
        }
        else
        {
            isDialogue = false; 
        }
    }

    public void CloseOptions()
    {
        dialogueOptionUI.SetActive(false);
    }

    private void OptionsParser(DialogueBase db)
    {
        if(db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;

            optionButtons[0].GetComponent<Button>().Select();

            for( int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].SetActive(false);
            }

            for(int i = 0; i < optionsAmount; i++)
            {
                optionButtons[i].SetActive(true);
                optionButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogueOptions.optionsInfo[i].buttonName;
                UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                if(dialogueOptions.optionsInfo[i].nextDialogue != null)
                {
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo [i].nextDialogue;
                }
                else
                {
                    myEventHandler.myDialogue = null;
                }
            }
        }
        else
        {
            isDialogueOption = false;
        }
        
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(isDialogue)
            {
                DequeueDialogue();
            }
        }
    }
    

}
