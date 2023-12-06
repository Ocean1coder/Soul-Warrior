using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spellPrefab;

    // private GameObject enemy;

    public float inDistance = 5;
    public float outDistance = 1;

    private Transform enemyPosition;

    private GameObject enemyTarget;

    public EnergryBar energryBar;

    public int MaxEnergry = 100;

    
    private int energry = 100;

    public int Energry
    {
        get { return energry; }
        set
        {
            energry = value;
            
        }
    }


    private void Start()
    {
        if(energry == 0)
            Energry = MaxEnergry;

        energryBar.SetMaxEnergry(energry);

        // enemyPosition = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        
    }

    public void TakeEnergry() 
    {
        if(energry < MaxEnergry )
        {
            energry += 15;
        }

        energryBar.SetEnergry(energry);
        
    }

    public void TakeEnergryShop() 
    {
        if(LootCoin.coinValue >= 5 )
        {
            if(energry < MaxEnergry )
            {
                energry += 15;
            }

                energryBar.SetEnergry(energry);

            LootCoin.coinValue -= 5;
        }

        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Energry") 
        {
            TakeEnergry();
            
            Destroy(other.gameObject);
        }

        Debug.Log("KAt");
    }

    // void Start()
    // {
        
        
    // }

    void Update()
    {

        // enemyPosition = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();

        // enemyPoint = GameObject.FindGameObjectWithTag("Enemy");

        if(Input.GetKeyDown(KeyCode.Alpha1) && MaxEnergry >= 30)
        {
            // if(Vector2.Distance(transform.position, enemyPosition.position) < inDistance && Vector2.Distance(transform.position, enemyPosition.position) > outDistance)
            // {
            //     CastSpellEffect();
            //     Debug.Log("1");
            
            // }
            // if(Vector2.Distance(transform.position, enemyPosition.position) > inDistance && Vector2.Distance(transform.position, enemyPosition.position) < outDistance)
            // {
                
            
            // }

            CastSpellEffect();
            
        }
         
        
        
        
    }

    

    private void InDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, inDistance);

        
    }


    public void CastSpellEffect()
    {
        MaxEnergry -= 30;

        energryBar.SetEnergry(MaxEnergry);

        Instantiate(spellPrefab[0], transform.position, Quaternion.identity);
    }

    

}
