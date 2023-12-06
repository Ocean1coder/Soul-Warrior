using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LootCoin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    
    public static int coinValue = 1000;

    void Awake()
    {
        coinText = GetComponent<TextMeshProUGUI>();

        
    }
    

    void Update()
    {
        
        coinText.text = "x " + coinValue; 
    }


}
