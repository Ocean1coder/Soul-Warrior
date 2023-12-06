using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{

    public HealthBar healthBar;
   
    public GameManagerScripts overScene;

    public int MaxHealth = 100;

    [SerializeField]
    private int health = 50;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            
        }
    }

   

    private void Start()
    {
        if(health == 0)
            Health = MaxHealth;

        healthBar.SetMaxHealth(health);
    }

    

    public void TakeDamage(int damage) 
    {
    

        health -= damage;

        healthBar.SetHealth(health);

        if(Health <= 0) 
        {
            Die();
        }
        
    }

    public void TakeHeal() 
    {
        if(health < MaxHealth )
        {
            health += 3;
        }

        healthBar.SetHealth(health);
        
    }

    public void TakeHealShop() 
    {
        if(LootCoin.coinValue >= 5 )
        {
            if(health < MaxHealth )
            {
                health += 5;
            }

                healthBar.SetHealth(health);

            LootCoin.coinValue -= 5;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Heal") 
        {
            TakeHeal();
            
            Destroy(other.gameObject);

            Debug.Log("KAx");
        }

       
    }

    private void Die() 
    {
        overScene.GameOver();
        Debug.Log("IM DEAD");
        Destroy(gameObject);
    }
}
