using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
   
    // public Image hp;
    public TextMeshProUGUI valueText; 

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;  
           
    }

    public void SetHealth(int Health)
    {
        slider.value = Health;
    }

    void Update()
    {
        valueText.text = slider.value.ToString();
    }
    
    

}
