using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTarget : Interactable
{
   public DialougeTrigger DT;

   public override void Interact()
   {
        DT.index = 1;

        base.Interact();
   }
}
