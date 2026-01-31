using System;
using UnityEngine;

public class MegaJumpAttack : EnemyAttack
{
    protected override float Cooldown { get; }
    [SerializeField] private float velocity;
    protected override void DoAttack()
    {
        //solo embiste y le aplica un knockback al jugador
        Vector3 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * velocity;
        
        
    }
    
    //el player lo tienes por ahí

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable player) && other.CompareTag("Player"))
        {
            player.MakeDamage(damage,this.gameObject);
        }
    }
}
