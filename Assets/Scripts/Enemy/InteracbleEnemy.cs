using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracbleEnemy : MonoBehaviour
{
    public float interactRange = 2f;

    public GameObject player;

    private Transform playerPoint;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

    }

    void Update()
    {



        if(Vector2.Distance(gameObject.transform.position, GameManagerScripts.instance.player.position) < interactRange)
        {

            Interact();

            
            
        }
    }

    public virtual void Interact()
    {
        
    playerPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
        

    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
