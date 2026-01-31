using UnityEngine;

public class LargeDistanceEnemy : Enemy
{
    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange; //este enemigo ataca desde una distancia mayor porque realiza un ataque a larga distancia
    
    //referencias
    
    
    //clase padre
    
    protected override float ChaseRange => chaseRange;
    protected override float AttackRange => attackRange;
}
