using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUi : MonoBehaviour
{
    public static CanvasUi instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
