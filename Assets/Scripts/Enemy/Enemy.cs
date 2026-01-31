using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    //queremos que tenga una vida, que sea atacable y que se mueva

    [SerializeField] private int lifeCounter;
    //rangos de vision
    protected virtual float ChaseRange { get; }
    protected virtual float AttackRange { get; }
    [SerializeField] private LayerMask playerLayer; //poner el jugador en la layer del jugador
   
    //referencias
    private Transform player;
    protected Rigidbody rb;
    [SerializeField] private EnemyAttack enemyAttack;
    
    
    //states
    private string state = "chase";

    [SerializeField] private float velocity;
    
    
    private float maxAttackTimer = 1.3f;
    private float attackTimer;
    
    
    protected virtual void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        attackTimer = maxAttackTimer;
        
        
    }
    
    //necesito gizmos para verlo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void Update() //update ejecuta cada frame, NO USAR WHILE
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


                attackTimer -= Time.deltaTime;

                if (attackTimer <= 0)
                {
                    attackTimer = maxAttackTimer;

                    if (inAttack)
                    {
                        enemyAttack.SetTarget(player);
                        enemyAttack.TryAttack();
                    }

                    else state = "chase";
                }

                break;
        }
    }

    private bool PlayerInChaseRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ChaseRange, playerLayer); 
        if (colliders.Length > 0) //si el array de colliders es mayor que cero porque el overlapSphere detecta colision en una posicion dentro del radio y de la layer indicada
        {
            player =  colliders[0].transform; //toma el transform del collider que ha recogido y lo mete en el player
            return true;
        }

       
        return false;
    }
    
    private bool PlayerInAttackRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, AttackRange, playerLayer);
        if (colliders.Length > 0)
        {
            player =  colliders[0].transform;
            return true;
        }
      
        return false;
    }
    
    private void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, velocity * Time.deltaTime);
        
        //esto hay que probarlo en 3d
    }

    //lo de ser atacable
    public void MakeDamage(float damage, GameObject damagedealer)
    {
        lifeCounter--;
        Vector3 knockDirection = this.transform.position - damagedealer.transform.position;
        Knockback(knockDirection,damage);
        if (lifeCounter == 0) Destroy(gameObject);
    }

    private void Knockback(Vector3 knockDirection, float damage)
    {
        rb.isKinematic = false;
        rb.AddForce(knockDirection * damage, ForceMode.Impulse);
    }
}
