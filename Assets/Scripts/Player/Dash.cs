using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{   
    private float speed ;
    private float activeSpeed;
    public float dashSpeed;

    public float dashLength = 5f, dashCoolDown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    void Start()
    {
        activeSpeed = speed;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeSpeed = dashSpeed;
                dashCounter = dashLength;
            }
            Debug.Log("2");
        }
        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeSpeed = speed;
                dashCoolCounter = dashCoolDown;
            }
        }
        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}