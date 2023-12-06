using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DialougeTrigger))]
public class DialogueEvent : Interactable    
{
    [Header("Target Info")]
    public int targetIndex;
    public int targetLine;
    

    public UnityEvent unityEvent;
    private DialougeTrigger dialogueTrigger;
    private bool isAdded;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialougeTrigger>();
        interactRange = dialogueTrigger.interactRange;
    }

    public override void Interact()
    {
        if(isAdded || DialogueManager.instance.isDialogue) return;

        if(dialogueTrigger.index == targetIndex)
        {
            DialogueManager.instance.onDialogueLineCallBack += GenericEvent;
            isAdded = true;
        }

        base.Interact();

    }

    public void GenericEvent(int line)
    {
        if(line == targetLine)
        {
            unityEvent.Invoke();

            DialogueManager.instance.onDialogueLineCallBack -= GenericEvent;
        }
    }
}
