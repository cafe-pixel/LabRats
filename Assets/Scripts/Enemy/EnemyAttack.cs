using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    protected abstract float Cooldown { get; }

    protected Transform player;
    protected Rigidbody rb;
    
    [SerializeField] protected float damage;
    public float lastAttackTime; //momento en el que el enemigo hizo su último ataque

    protected virtual void Start()
    {
        if (!player) player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    public void TryAttack()
    {
        Vector3 lookDir = player.position - transform.position;
        lookDir.y = 0;
        transform.rotation = Quaternion.LookRotation(lookDir);
        
        
        if (Time.time < lastAttackTime + Cooldown)
            return; //Si el tiempo del juego es menor que el ultimo ataque + el cooldown no permite realizar el ataque
        
        Debug.Log("He llegado a intebtar el ataque");
        DoAttack();
        lastAttackTime = Time.time; //Setea el ultimo ataque en el tiempo real de juego      
        
    }

    public void SetTarget(Transform target)
    {
        player = target;
    }

    protected abstract void DoAttack();
}

