using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter instance;
    public int enemyCounter { get; set; }

    void Awake()
    {
        instance = this;
    }

    public void AddEnemy()
    {
        enemyCounter++;
    }
}