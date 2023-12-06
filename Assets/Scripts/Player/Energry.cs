using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energry : MonoBehaviour
{
    public int energry;
    public int currentEnergry;
    
    public EnergryBar energryBar;

    private void Awake() 
    {

        currentEnergry = energry;

        energryBar.SetMaxEnergry(currentEnergry);
    

    }

    void Update()
    {
       
        // if(currentHealth <= 0) {
        //    Destroy(gameObject);
        // }
                
    }
 

    public void SetEnergry(int maxEnergry, int energry) 
    {
        this.currentEnergry = maxEnergry;
        this.energry = energry;
    }

    public void TakeEnergry() 
    {
        if(energry < currentEnergry)
        {
            energry += 1;
        }

        energryBar.SetEnergry(energry);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Energry") 
        {
            TakeEnergry();
            Destroy(other.gameObject);
        }
    }
    
}
