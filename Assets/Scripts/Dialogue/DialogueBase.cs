using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues/Dialogue Basic")]
public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        
        public PlayerProfile player;
        // public string myName;
        [TextArea(4, 8)]
        public string myText;

    }

    [Header("Insert Dialogue Information Below")]
    public Info[] dialogueInfo;
}
