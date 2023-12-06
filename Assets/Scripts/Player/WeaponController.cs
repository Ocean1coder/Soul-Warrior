using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{ 

    private void Update() 
    {

        ControllerGun();

    }
    void ControllerGun() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) 
        {
            transform.localScale = new Vector3(0.1f, -0.1f, 0f);
        } 
        else 
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0f);
        }

    }
    
}