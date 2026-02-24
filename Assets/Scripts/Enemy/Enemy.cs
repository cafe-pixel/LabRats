using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour, IDamagable
{
    //queremos que tenga una vida, que sea atacable y que se mueva

    [SerializeField] private float lifeCounter;
    //rangos de vision
    protected virtual float ChaseRange { get; }
    protected virtual float AttackRange { get; }
    [SerializeField] private LayerMask playerLayer; //poner el jugador en la layer del jugador
   
    //referencias
    protected Transform player;
    protected Rigidbody rb;
    [SerializeField] protected EnemyAttack enemyAttack;
    
    
    //states
    protected string state = "chase";

    [SerializeField] protected float velocity;


    protected float maxAttackTimer = 1.3f;
    protected float attackTimer;
    
    //sonidos
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip audioJump;
    [SerializeField] public AudioClip audioHeart;
    
    
    
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

    protected virtual void Update() //update ejecuta cada frame, NO USAR WHILE
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
                        enemyAttack.TryAttack();
                    }

                    else state = "chase";
                

                break;
        }
    }

    protected bool PlayerInChaseRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ChaseRange, playerLayer); 
        if (colliders.Length > 0) //si el array de colliders es mayor que cero porque el overlapSphere detecta colision en una posicion dentro del radio y de la layer indicada
        {
            player =  colliders[0].transform; //toma el transform del collider que ha recogido y lo mete en el player
            return true;
        }

       
        return false;
    }
    
    protected bool PlayerInAttackRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, AttackRange, playerLayer);
        if (colliders.Length > 0)
        {
            Debug.Log("He tomado al player");
            player =  colliders[0].transform;
            return true;
        }
      
        return false;
    }

    protected void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, velocity * Time.deltaTime);
        
        //esto hay que probarlo en 3d
    }

    //lo de ser atacable
    public void MakeDamage(float damage, GameObject damagedealer)
    {
        audioSource.PlayOneShot(audioHeart);
        lifeCounter -= damage;
        
        Vector3 knockDirection = damagedealer.transform.position - this.transform.position;
        Knockback(knockDirection,damage);
        if (lifeCounter <= 0) Destroy(gameObject,0.2f);
    }

    private void Knockback(Vector3 knockDirection, float damage)
    {
        rb.isKinematic = false;
        rb.AddForce(knockDirection * damage, ForceMode.Impulse);
    }
}
