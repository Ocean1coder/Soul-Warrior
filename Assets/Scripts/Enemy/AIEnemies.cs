using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemies : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float followDistance;

    private GameObject player;
    private Transform playerPoint;
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();

    }
    void Update()
    {
        playerPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if(Vector2.Distance(transform.position, playerPoint.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPoint.position, speed * 0 * Time.deltaTime);

            anim.SetBool("Idle", true);
            

        }
        // else if(Vector2.Distance(transform.position, playerPoint.position) > stoppingDistance && Vector2.Distance(transform.position, playerPoint.position) < followDistance)
        // {
        //     transform.position = Vector2.MoveTowards(transform.position, playerPoint.position, 0 * Time.deltaTime);
        //     // transform.position = this.transform.position;

        //     anim.SetBool("Idle", false);
        // }
        else if(Vector2.Distance(transform.position, playerPoint.position) < followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPoint.position, speed * Time.deltaTime);

            anim.SetBool("Idle", false);
            
            
        }
        
    }
}   
