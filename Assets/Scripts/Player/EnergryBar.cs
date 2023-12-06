using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergryBar : MonoBehaviour
{
    
    public Slider slider;
    
    public TextMeshProUGUI ePText;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxEnergry(int Energry)
    {
        slider.maxValue = Energry;
        slider.value = Energry;  
    }

    public void SetEnergry(int Energry)
    {
        slider.value = Energry;
    }
    
    void Update()
    {
        ePText.text = slider.value.ToString();
    }
}
