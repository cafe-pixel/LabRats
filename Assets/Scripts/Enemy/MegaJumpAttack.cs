using UnityEngine;

public class MegaJumpAttack : EnemyAttack
{
    protected override float Cooldown { get; }
    protected override void DoAttack()
    {
        //solo embiste y le aplica un knockback al jugador
        
        
    }
    
    //el player lo tienes por ahí

    protected override void Start()
    {
        base.Start();
    }
}
