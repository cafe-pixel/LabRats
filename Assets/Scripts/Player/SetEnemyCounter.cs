using UnityEngine;

public class SetEnemyCounter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCounter>(out EnemyCounter enemyN))
        {
            enemyN.enemyCounter = 0;
        }
    }
}
