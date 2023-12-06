using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoots : MonoBehaviour
{
    
    public GameObject Bullet;
    
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    private float timeBtwFire;
   

    public int currentAmmo = 10;
    public int magAmmo = 20;
    public int maxAmmo = 10;
    public float reloadTime = 1.5f;

    public GameObject muzzleFlash;
    [Range(0,5)]
    public int framesToFlash = 1;

    bool isFlashing = false;

    bool isReloading = false;

    public Animator anim;


    void Start()
    {
        muzzleFlash.SetActive(false);

        currentAmmo = maxAmmo;
        
    }

    void OnEnable()
    {
        isReloading = false;
        anim.SetBool("ReLoad", false);
    }

    private void Update() 
    {
        if(isReloading)
            return;

        if(currentAmmo <= 0 && magAmmo > 0)
        {
            // anim.SetBool("ReLoad", true);
            // return;


            if(Input.GetMouseButton(1))
            {
                StartCoroutine(ReLoad());
                anim.SetBool("ReLoad", true);
                return;
            // if(Input.GetKeyDown(KeyCode.R))
            // {
            //     StartCoroutine(ReLoad());
            //     return;
            // }
           
            }
        // if(Input.GetMouseButton(1))
        // {
        //         StartCoroutine(ReLoad());
        //         return;
        }



        timeBtwFire -= Time.deltaTime;

        if(Input.GetMouseButton(0) && timeBtwFire < 0 && currentAmmo >= 1) 
        {   
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            else
            {
                Shoot();
            }
            
            
            
        }
         

    }

    IEnumerator ReLoad()
    {   
        
            isReloading = true;

            Debug.Log("Is Reloading");

            anim.SetBool("ReLoad", true);

            yield return new WaitForSeconds(reloadTime - .25f);

            anim.SetBool("ReLoad", false);

            yield return new WaitForSeconds(.25f);

            currentAmmo = maxAmmo;
            
            Debug.Log("Reloading Complete");
            
            isReloading = false;
            
            magAmmo -= maxAmmo;
        
        
        
    }
    
    

    public void Shoot() 
    {   

        currentAmmo--;

        timeBtwFire = TimeBtwFire;


        EnemyController enemy = GetComponent<EnemyController>();

        GameObject BulletTmp = Instantiate(Bullet, firePos.position, Quaternion.identity);
        Destroy(BulletTmp, 1f); 
        Rigidbody2D rb = BulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        
        if(!isFlashing)
        {
            StartCoroutine(DoFlash());
        }
            
    }

    IEnumerator DoFlash()
    {
        muzzleFlash.SetActive(true);
        var framesFlashed = 0;
        isFlashing = true;

        while (framesFlashed <= framesToFlash)
        {
            framesFlashed ++;
            yield return null;
        }

        muzzleFlash.SetActive(false);
        isFlashing = false;
    }


    public void AddAmmo()
    {
        if(LootCoin.coinValue >= 5 )
        {
            magAmmo += 10;

            LootCoin.coinValue -= 5;
        }
        
        
        
    }

    
}

