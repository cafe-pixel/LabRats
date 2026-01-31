using System.Collections;
using UnityEngine;

public class JumperEnemy : Enemy
{
    private bool isMoving;

    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange; //este enemigo ataca desde una distancia mayor porque realiza un ataque a larga distancia
    
    //referencias
    
    
    //clase padre
    
    protected override float ChaseRange => chaseRange;
    protected override float AttackRange => attackRange;
    
    [SerializeField] private float jumpForce;
    protected override void Start()
    {
        base.Start();
        rb.isKinematic = false;
        //realizar un salto
        
        StartCoroutine(EnemyJump());
    }


    private IEnumerator EnemyJump()
    {
        while (isMoving) 
        {
            yield return new WaitForSeconds(1);
            
            
            rb.AddForce(new Vector3(0, 1, 0).normalized * jumpForce, ForceMode.Impulse);
            
        }
        
    }
}
