using UnityEngine;

public class MegaJumpAttack : EnemyAttack
{
    protected override float Cooldown { get; }
    protected override void DoAttack()
    {
        //toma al player y salta sobre él
    }
    
    //el player lo tienes por ahí

    protected override void Start()
    {
        base.Start();
    }
}
