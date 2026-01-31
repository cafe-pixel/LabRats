using System;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject spawnableEnemy;
    //falta hacer numero de enemigos máximo que habrá instanciado
   [Tooltip("Si quieres 6 enemigos mete como int el numero 7, así sucesivamente")] [SerializeField] private int enemyCounter;
    private void OnTriggerEnter(Collider other)
    {
        //aqui hay que meterle un for
        for (int i = 0; i < enemyCounter; i++)
        {
            Instantiate(spawnableEnemy, transform.position, transform.rotation);
        }
            
    }
}
