using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float life = 3f;
    [SerializeField] private float velocity = 7f;
    [SerializeField] private float damage = 2f;


    public Vector3 dir;
    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = dir * (velocity);
        
        

        Destroy(gameObject,life);
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable enemy)&&other.CompareTag("Enemy"))
        {
            enemy.MakeDamage(damage, this.gameObject);
            Debug.Log("He pegadoo un enemigo");
            EnemyCounter.instance.AddEnemy();
            Destroy(gameObject);
        }
    }
    
}
