using UnityEngine;

public class Enemigo2Disparos : MonoBehaviour
{
    [Header("Rango y disparo")]
    public float detectionRange = 4f;   
    public float fireRate = 5f;         
    [Header("Bala")]
    public GameObject bulletPrefab;
    public Transform firePoint;         
    public Vector3 bulletDirection = Vector3.forward; 
    
    [Header("Sonidos")]
    public AudioSource audioSource;
    public AudioClip sonidoDisparo;
    public AudioClip sonidoGolpe;

    [Header("Jugador")]
    public Transform player;

    private float fireTimer = 0f;
    private bool playerDetected = false;
    
    public int vidaMaxima = 20;
    private int vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;
        }

        if (firePoint == null)
        {
            firePoint = transform; 
        }
    }

    void Update()
    {
        DetectarJugador();

        if (playerDetected)
        {
            Vector3 lookDir = player.position - transform.position;
            lookDir.y = 0;
            transform.rotation = Quaternion.LookRotation(lookDir);
            
            fireTimer -= Time.deltaTime;

            if (fireTimer <= 0f)
            {
                Disparar();
                fireTimer = fireRate;
            }
        }
    }

    void DetectarJugador() //pasar de animacion idle a movimiento
    {
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);
        playerDetected = dist <= detectionRange;
    }

    void Disparar()  //añadir animación
    {
        if (bulletPrefab == null || firePoint == null || player == null) return;
        
        
        Vector3 direccion = (player.position - firePoint.position).normalized;


        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direccion));
        
        
        BulletEnemigo bulletScript = bullet.GetComponent<BulletEnemigo>();
        if (bulletScript != null)
        {
            bulletScript.dir = direccion;
        }

        //audio
        if (audioSource != null && sonidoDisparo != null)
        {
            audioSource.PlayOneShot(sonidoDisparo);
        }
        
    }
    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
    
    void OnTriggerEnter(Collider collision)       //Función para recibir daño, cambiar etiqueta y parametros
    {
        if (collision.gameObject.CompareTag("Espada"))  
        {
            vidaActual -= 5;
            if (audioSource != null && sonidoGolpe != null)
                audioSource.PlayOneShot(sonidoGolpe);
            if (vidaActual <= 0)
            {
                Morir();
            }
        }
    }

    void Morir()   //función de morir, añadir animación de muerte
    {
        Debug.Log(gameObject.name + " ha muerto.");
        Destroy(gameObject); 
    }
}
