using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
public class EventBehaviour : ScriptableObject
{
    // public int hp = 5;

    public void TestEvent()
    {
        Debug.Log("Test events Succesfull");
        // Destroy(References.instance.testGameObject);

        
    }
}
