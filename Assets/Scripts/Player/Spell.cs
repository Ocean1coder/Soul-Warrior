using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int spellDamage;

    private Transform target;


    void Start()
    {   


        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = target.position - transform.position;

        rb.velocity = direction.normalized * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemiesHealth>().TakeDamage(spellDamage);

            Debug.Log("HIT ENEMY");

            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Box") 
        {   
            other.gameObject.GetComponent<BoxDrop>().TakeDamage(spellDamage);

            Destroy(gameObject);
        }
    }
}
