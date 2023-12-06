using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoText : MonoBehaviour
{   
    public Shoots weapon;
    public TextMeshProUGUI textAmmo;
    
    void Start()
    {
        UpdateAmmoText();
    }

    
    private void Update()
    {
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        textAmmo.text = $"{weapon.currentAmmo} / {weapon.magAmmo}";
    }
}
