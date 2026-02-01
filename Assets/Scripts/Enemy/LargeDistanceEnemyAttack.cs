using UnityEngine;

public class LargeDistanceEnemyAttack : EnemyAttack
{
    
    [SerializeField] private float fireRate;         
    [Header("Bala")]
    public GameObject bulletPrefab;
    public Transform firePoint;         
    
    
    


    private float fireTimer = 0f;
    
    
    public int vidaMaxima = 20;
    private int vidaActual;

    protected override float Cooldown => 0;

    void Start()
    {
        fireTimer = 0f;

        if (!player)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p) player = p.transform;
        }

        if (!firePoint) firePoint = transform;
    }

    protected override void DoAttack()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            
            Disparar();
            fireTimer = fireRate;
        }
    }

    void Update()
    {
        if (player)
        {
            Vector3 lookDir = player.position - transform.position;
            lookDir.y = 0;
            transform.rotation = Quaternion.LookRotation(lookDir);
            
            
        }
    }


    void Disparar()  //añadir animación
    {
        if (bulletPrefab == null || firePoint == null || player == null) return;
        
        
        Vector3 direccion = (player.position - firePoint.position).normalized;


        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direccion));
        
        
        if (bullet.TryGetComponent(out BulletEnemigo bulletEnemigo))
        {
            bulletEnemigo.dir = direccion;
        }

        
    }
    
    
    void OnTriggerEnter(Collider other)       //Función para recibir daño, cambiar etiqueta y parametros
    {
        if (other.TryGetComponent<IDamagable>(out IDamagable player) && other.CompareTag("Player"))
        {
            player.MakeDamage(damage,this.gameObject);
            
        }
    }

   
}
