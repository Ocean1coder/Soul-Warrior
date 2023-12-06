using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    int totalWeapon = 1;
    public int weaponIndex;

    public GameObject[] guns;
    public GameObject weapon;
    public GameObject currentGun;

    private 

    void Start()
    {
        totalWeapon = weapon.transform.childCount;
        guns = new GameObject[totalWeapon];

        for(int i = 0; i < totalWeapon; i++)
        {
            guns[i] = weapon.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
        weaponIndex = 0;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(weaponIndex < totalWeapon - 1)
            {
                guns[weaponIndex].SetActive(false);
                weaponIndex += 1;
                guns[weaponIndex].SetActive(true);
                currentGun = guns[weaponIndex];
            }
            else if(weaponIndex > 0)
            {
                guns[weaponIndex].SetActive(false);
                weaponIndex -= 1;
                guns[weaponIndex].SetActive(true);
                currentGun = guns[weaponIndex];
            }
        } 
               
    }
}
