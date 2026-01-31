using UnityEngine;

public class BulletEnemigo : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir;

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
