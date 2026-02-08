using System;
using UnityEngine;

public class SpawnerVidaDependienteEnemigos : MonoBehaviour
{
    [SerializeField] private int nEnemies;
    
    [Tooltip("ZonaDeTrigger")][SerializeField] private BoxCollider box;
    [Tooltip("BichitoTonto")][SerializeField] private BoxCollider boxMesh;
    [Tooltip("BichitoTonto")][SerializeField] private MeshRenderer mesh;
    
   


    private void Start()
    {
        
        //empieza con el trigger apagado, este se enciende cuando nEnemies es correcto
        mesh.enabled = false;
        boxMesh.enabled = false;
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (nEnemies == EnemyCounter.instance.enemyCounter)
        {
            box.enabled = true;
            mesh.enabled = true;
            boxMesh.enabled = true;
            
        }
        
    }
}
