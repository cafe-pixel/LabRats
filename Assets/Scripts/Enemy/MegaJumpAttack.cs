using System;
using System.Collections;
using UnityEngine;

public class MegaJumpAttack : EnemyAttack
{
    protected override float Cooldown { get; }
    [SerializeField] private float velocity;
    [SerializeField] private JumperEnemy jumperEnemy;
    
    private bool isMoving;
    
    private bool canJump;
    protected override void DoAttack()
    {
        //solo embiste y le aplica un knockback al jugador

        isMoving = true;
        
        
        Vector3 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * velocity;
        StartCoroutine(EnemyJump());
        
    }
    
    //el player lo tienes por ahí

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable player) && other.CompareTag("Player"))
        {
            player.MakeDamage(damage,this.gameObject);
        }
    }
    private IEnumerator EnemyJump()
    {
        while (isMoving) 
        {
            yield return new WaitForSeconds(1);


            if (canJump)
            {
                rb.AddForce(Vector3.up * jumperEnemy.jumpForce, ForceMode.Impulse);
                jumperEnemy.audioSource.PlayOneShot(jumperEnemy.audioJump);
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
