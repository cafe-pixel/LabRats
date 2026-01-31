using UnityEngine;

public class BulletEnemigo : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float life = 3f;
    [SerializeField] private float damage = 2f;


    public Vector3 dir;

    void Start()
    {
        Destroy(gameObject, life);
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
