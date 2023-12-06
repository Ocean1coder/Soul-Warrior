using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float meleeSpeed;

    [SerializeField] private int meleeDamage;

    float timeUntilMelee;

    

    private void Update()
    {
        

        if(timeUntilMelee <= 0f)
        {
            
            animator.SetBool("Idle", false);

            if(Input.GetMouseButtonDown(0))
            {

                // animator.SetTrigger("Attack");
                // timeUntilMelee = meleeSpeed;



                

                if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            else
            {
                animator.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
                
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
            animator.SetBool("Idle", false);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemiesHealth>().TakeDamage(meleeDamage);

            Debug.Log("HIT ENEMY");
        }

        if(other.gameObject.tag == "Box") 
        {   
            other.gameObject.GetComponent<BoxDrop>().TakeDamage(meleeDamage);
        }
    }

    public void AddDamageMelee() 
    {   
        if(LootCoin.coinValue >= 5 )
        {
            meleeDamage += 3;

            LootCoin.coinValue -= 5;
        }
        
        
    }

}

