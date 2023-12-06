using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestClose, chestOpen;

    void Start()
    {
        chestClose.SetActive(true);
        chestOpen.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            chestClose.SetActive(false);
            chestOpen.SetActive(true);
            if(chestOpen)
            {
                GetComponent<DropHeal>().InstantiateLoot(transform.position);
                GetComponent<DropEnergry>().InstantiateLoot(transform.position);
                GetComponent<DropCoin>().InstantiateLoot(transform.position);

                Destroy(chestClose);
            }
            

            
        }
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.gameObject.tag == "Player")
    //     {
    //         chestClose.SetActive(true);
    //         chestOpen.SetActive(false);
    //     }
    // }
}
