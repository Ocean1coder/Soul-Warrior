// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WeaponMelee : MonoBehaviour
// {
//     public SpriteRenderer characterRenderer, weaponRenderer;

//     public Vector2 PointerPosition {get; set; }

//     public Animator animator;
//     public float delay = 0.3f;
//     private bool attackBlocked;

//     private void Update()
//     {
//         Vector2 direction = (PointerPosition - (Vector2)transform.position).normalized;
//         transform.right = direction;

//         Vector2 scale = transform.localScale;
//         if( direction.x < 0)
//         {
//             scale.y = -1;
//         } 
//         else if(direction.x > 0)
//         {
//             scale.y = 1;
//         }
//         transform.localScale = scale;

//         if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
//         {
//             weaponRenderer.sortingOder = characterRenderer.sortingOder - 1;
//         }
//         else
//         {
//             weaponRenderer.sortingOder = characterRenderer.sortingOder + 1;
//         }
//     }

//     public void Attack()
//     {
//         if(attackBlocked)
//         return;
//         animator.SetTrigger("Attack");
//         attackBlocked = true;
//         StartCoroutine(DelayAttack());
//     }

//     private IEnumerator DelayAttack()
//     {
//         yield return new WaitForSeconds(delay);
//         attackBlocked = false;
//     }
// }
