using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class EnemyController : MonoBehaviour
{

    private Animator anim;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    
   

    private void Awake() 
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();


        

    }
    
    void Update() 
    {
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        // Debug.Log(distance);

        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(0, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        dir.Normalize();
        movement = dir;

        


        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) 
        {
            transform.localScale = new Vector3(0.5f, -0.5f, 0f);
        } else 
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0f);
        }


    }
    
    
    private void FixedUpdate() 
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 dir) 
    {
        rb.MovePosition((Vector2)transform.position);
    }

    
    
    
   

    
}
