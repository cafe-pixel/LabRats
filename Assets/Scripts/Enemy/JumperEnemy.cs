using System;
using System.Collections;
using UnityEngine;

public class JumperEnemy : Enemy
{
    private bool isMoving;

    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange; //este enemigo ataca desde una distancia mayor porque realiza un ataque a larga distancia

    private bool canJump;
    protected override float ChaseRange => chaseRange;
    protected override float AttackRange => attackRange;
    
    [SerializeField] public float jumpForce;
    
    
    //anims
   //[SerializeField] private RuntimeAnimatorController animator;
    
    
    protected override void Start()
    {
        base.Start();
        rb.isKinematic = false;
        isMoving = true;
        canJump = true;
        //realizar un salto
        
        StartCoroutine(EnemyJump());
    }

 /*   private void Attack()
    {
        animator.SetTrigger("Attack");
    }*/


    private IEnumerator EnemyJump()
    {
        while (isMoving) 
        {
            yield return new WaitForSeconds(1);


            if (canJump)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                audioSource.PlayOneShot(audioJump);
            }
            
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            canJump = false;
        }
    }
    
    
}
