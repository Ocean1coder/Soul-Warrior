using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float bulletForce;
    public int bulletDamageEnemies;
    private float timer;
    
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletForce;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Player") 
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(bulletDamageEnemies);

            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Box") 
        {   
            other.gameObject.GetComponent<BoxDrop>().TakeDamage(bulletDamageEnemies);
            
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Block") 
        {   
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Tiles") 
        {   
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Bullet") 
        {   
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {

    //     if(other.gameObject.tag == "Player") 
    //     {
    //         other.gameObject.GetComponent<Health>().TakeDamage(damage);

    //         Destroy(gameObject);
    //     }
    //     if(other.gameObject.tag == "Box") 
    //     {   
    //         other.gameObject.GetComponent<BoxDrop>().TakeDamage(damage);
            
    //         Destroy(gameObject);
    //     }
    //     if(other.gameObject.tag == "Block") 
    //     {   
    //         Destroy(gameObject);
    //     }
    //     if(other.gameObject.tag == "Tiles") 
    //     {   
    //         Destroy(gameObject);
    //     }
    //     if(other.gameObject.tag == "Bullet") 
    //     {   
    //         Destroy(gameObject);
    //     }
    // }
}
