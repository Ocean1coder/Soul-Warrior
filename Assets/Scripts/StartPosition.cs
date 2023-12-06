using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Start Position", menuName = "Positions")]
public class StartPosition : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initialValue;
    
    public Vector2 defaultValue;

    public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
       
    }

    public void OnBeforeSerialize()
    {

    }
}
