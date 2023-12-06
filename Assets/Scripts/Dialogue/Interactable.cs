using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRange = 0.75f;

    void Update()
    {
        if(Vector2.Distance(gameObject.transform.position, GameManagerScripts.instance.player.position) < interactRange)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                Interact();
            }
        }
    }

    public virtual void Interact()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
