using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public HealthBar healthBar;
   
    public GameManagerScripts overScene;
    
    public int currentHealth = 100;
    

    [SerializeField]
    private int health = 5;
    
    public int Healther
    {
        get {return health; }
        set 
        {
            health = value;
        }
    }

    private void Awake() 
    {

        if(health == 0)
        
        Healther = currentHealth;
        
        healthBar.SetMaxHealth(health);

    }

    public void TakeDamage(int damage) 
    {
    

        Healther -= damage;

        healthBar.SetHealth(Healther);

        if(health <= 0) 
        {
            Die();
        }
        
    }

    public void TakeHeal() 
    {
        if(health < currentHealth )
        {
            health += 1;
        }

        healthBar.SetHealth(health);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Heal") 
        {
            TakeHeal();
            Destroy(other.gameObject);
        }
    }
    

    private void Die() 
    {
        overScene.GameOver();
        Debug.Log("IM DEAD");
        Destroy(gameObject);
    }

    void AddHealthCheat()
    {
       
        health += 100;
        currentHealth += 100;
        

        healthBar.SetMaxHealth(health);
    }

    

}
