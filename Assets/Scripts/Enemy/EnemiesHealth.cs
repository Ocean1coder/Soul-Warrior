using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    public EnemyProfile enemyProfile;

    public float speed;    
    public int damage;
    public float health;

    private Transform player;

    // private Health playerHealth;

    private PlayerHealth playerHealth;

    private float currentHealth;

    

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        currentHealth = health;

        SetEnemyValues();

    }
 

    public void SetEnemiesHealth(int maxHealth, int health) 
    {
        this.currentHealth = maxHealth;
        this.health = health;
    }

    private void SetEnemyValues() 
    {
        GetComponent<EnemiesHealth>().SetEnemiesHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

   public void TakeDamage(float damage)
    {
    
        health -= damage;

        if(health <= 0)
        {
            Die();
            
            
    
            
            
        }
        
    }

    private void Die()
    {

        if (GameManagerScripts.instance.onEnemyDeathCallBack != null) GameManagerScripts.instance.onEnemyDeathCallBack.Invoke(enemyProfile);

        GetComponent<DropCoin>().InstantiateLoot(transform.position);

        Debug.Log("IM DEAD");

        Destroy(gameObject);

        ScoreScripts.scoreValue += 10;
    }

    void OnCollisionEnter2D(Collision2D other) 
    {

        if(other.gameObject.tag == "Player") 
        {
           playerHealth.TakeDamage(damage);
        
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) 
    // {

    //     if(other.gameObject.tag == "Player") 
    //     {
    //        playerHealth.TakeDamage(damage);
        
    //     }
    // }
    
}
