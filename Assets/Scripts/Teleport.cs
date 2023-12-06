using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Teleport : MonoBehaviour
{
    public GameObject pointTeleport;
    private GameObject player;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.transform.position = new Vector2(pointTeleport.transform.position.x, pointTeleport.transform.position.y);

            
        }

        
    }
    
}
