using System;
using System.Collections;
using UnityEngine;

public class JumperEnemy : Enemy
{
    private bool isMoving;

    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange; //este enemigo ataca desde una distancia mayor porque realiza un ataque a larga distancia

    private bool canJump;
    private bool canDamage;
    protected override float ChaseRange => chaseRange;
    protected override float AttackRange => attackRange;
    
    [SerializeField] public float jumpForce;
    

    [SerializeField] private float damage;

    


    private void DoAttack()
    {
       
        //solo embiste y le aplica un knockback al jugador

        isMoving = true;


        Vector3 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * velocity);
    }



    protected override void Start()
    {
        base.Start();
        rb.isKinematic = false;
        isMoving = true;
        canJump = false;
        //realizar un salto
        
        StartCoroutine(EnemyJump());
        canDamage = true;

    }

 

     protected override void Update()
     {
         bool inChase = PlayerInChaseRange();
         bool inAttack = PlayerInAttackRange();

         switch (state)
         {

             case "chase":

                 if (inChase) Chase();

                 if (inAttack)
                 {
                     attackTimer = maxAttackTimer;
                     state = "attack";
                 }


                 break;

             case "attack":


                 if (inAttack)
                 {
                     enemyAttack.SetTarget(player);
                     transform.position = Vector3.MoveTowards(transform.position, player.position, velocity * Time.deltaTime);
                     DoAttack();
                     
                     
                 }
                 else state = "chase";


                 break;
         }
     }


    private IEnumerator EnemyJump()
    {
        while (true) 
        {
            yield return new WaitForSeconds(1);

            if (canJump)
            {
                Debug.Log("He saltado");
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
    
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable player) && other.CompareTag("Player"))
        {
            if (canDamage)
            {
                player.MakeDamage(damage,this.gameObject);
                StartCoroutine(damageCd());
            }
                
        }
    }

    private IEnumerator damageCd()
    {
        canDamage = false;
        yield return new WaitForSeconds(1);
        canDamage = true;
    }
    
    
}
