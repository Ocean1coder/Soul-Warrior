// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerEnergry : MonoBehaviour
// {
//     public EnergryBar energryBar;

//     public int MaxEnergry = 100;

    
//     private int energry = 100;

//     public int Energry
//     {
//         get { return energry; }
//         set
//         {
//             energry = value;
            
//         }
//     }


//     private void Start()
//     {
//         if(energry == 0)
//             Energry = MaxEnergry;

//         energryBar.SetMaxEnergry(energry);
//     }

//     public void TakeEnergry() 
//     {
//         if(energry < MaxEnergry )
//         {
//             energry += 15;
//         }

//         energryBar.SetEnergry(energry);
        
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if(other.gameObject.tag == "Energry") 
//         {
//             TakeEnergry();
            
//             Destroy(other.gameObject);
//         }

//         Debug.Log("KAt");
//     }
// }
