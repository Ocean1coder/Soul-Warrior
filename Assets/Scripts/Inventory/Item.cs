using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string myName;
    public string myDescription;
    public Sprite myIcon;
    public int maxStackSize = 1;
}
