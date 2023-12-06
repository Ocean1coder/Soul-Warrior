using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDrop : MonoBehaviour
{
    private int health = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        GetComponent<DropHeal>().InstantiateLoot(transform.position);
        GetComponent<DropEnergry>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }
 
}

