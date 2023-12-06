using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        
        if(other.gameObject.tag == "Block") 
        {   
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Tiles") 
        {   
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Enemy") 
        {
            other.gameObject.GetComponent<EnemiesHealth>().TakeDamage(bulletDamage);
            
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Box") 
        {   
            other.gameObject.GetComponent<BoxDrop>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "BulletEnemies") 
        {   
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if(other.gameObject.tag == "Enemy") 
        {
            other.gameObject.GetComponent<EnemiesHealth>().TakeDamage(bulletDamage);
            
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Box") 
        {   
            other.gameObject.GetComponent<BoxDrop>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "BulletEnemies") 
        {   
            Destroy(gameObject);
        }

    }

    public void AddDamageBullet() 
    {
        
        if(LootCoin.coinValue >= 5 )
        {
            bulletDamage += 3;

            LootCoin.coinValue -= 5;
        }
        
        
    }
    void AddDamageCheat()
    {
        bulletDamage += 1000;
    }
    

}
