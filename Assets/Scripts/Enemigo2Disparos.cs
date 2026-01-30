using UnityEngine;

public class Enemigo2Disparos : MonoBehaviour
{
    [Header("Rango y disparo")]
    public float detectionRange = 4f;   
    public float fireRate = 5f;         
    [Header("Bala")]
    public GameObject bulletPrefab;
    public Transform firePoint;         
    public Vector2 bulletDirection = Vector2.right; 
    
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
            fireTimer -= Time.deltaTime;

            if (fireTimer <= 0f)
            {
                Disparar();
                fireTimer = fireRate;
            }
        }
    }

    void DetectarJugador()
    {
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);
        playerDetected = dist <= detectionRange;
    }

    void Disparar()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bala = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        //bala.GetComponent<Bullet>().direction = bulletDirection;
        
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
    
    void OnTriggerEnter2D(Collider2D collision)
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

    void Morir()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        Destroy(gameObject); 
    }
}
