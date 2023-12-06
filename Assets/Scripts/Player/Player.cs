using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    private int speed = 4;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;
    bool facingRight = true;
    public StartPosition startPosition;
    public static int coinValue = 1;

    public static Player instance;
    
    // [SerializeField] private Transform minimapIcon;

    public Transform minimapIcon;

    public bool CheckFreeze()
    {
        bool b;

        if(DialogueManager.instance.isDialogue)
        {
            b = true;
        }
        else if( InventoryManager.instance.isInventory)
        {
            b = true;
        }
        else if(QuestManager.instance.isQuestUI)
        {
            b = true;
        }
        else if(QuestLog.instance.IsQuestLog)
        {
            b = true;
        }
        // else if(GameManagerScripts.instance.rewardManager.IsQuestReward)
        // {
        //     b = true;
        // }
        else
        {
            b = false;
        }

        return b;
    }

    [SerializeField]
    private string type;

     public string MyType
    {
        get
        {
            return type;
        }
        
    }
    

   

    private void Awake() 
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = startPosition.initialValue;
        // spriteRenderer = GetComponent<SpriteRenderer>();

        // minimapIcon = GetComponent<Transform>();
        
    }

    private void OnMovement(InputValue value) 
    {

        movement = value.Get<Vector2>();

        

        if(movement.x != 0 || movement.y != 0) 
        {
            

            anim.SetFloat("X", movement.x);
            anim.SetFloat("Y", movement.y);

           

            anim.SetBool("Idle", true);
        } 
        else 
        {
            anim.SetBool("Idle", false);
        }

        

    }

    private void FixedUpdate() 
    {

        

        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        

        if(CheckFreeze()) return;
       
    }
    private void Update() 
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // float horizontalInput = Input.GetAxis("Horizontal");

        // if (horizontalInput < 0) // Moving left
        // {
        //     spriteRenderer.flipX = true;
        // }
        // else if (horizontalInput > 0) // Moving right
        // {
        //     spriteRenderer.flipX = false;
        // }

        if(mousePos.x < transform.position.x && facingRight) 
        {
            flip();
        } 
        else if(mousePos.x > transform.position.x && !facingRight)
        {
            flip();
        }
        
    }

    void flip() 
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        
    } 

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Coin") 
        {
            LootCoin.coinValue += 1;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Energry") 
        {
            // other.gameObject.GetComponent<Shoots>().TakeEnergry();


            Destroy(other.gameObject);

            Debug.Log("KAt");
        }

        
    }

    public void AddSpeed() 
    {
        if(LootCoin.coinValue >= 5 )
        {
            speed += 1;

            LootCoin.coinValue -= 5;
        }
        
        
    }
    

}
