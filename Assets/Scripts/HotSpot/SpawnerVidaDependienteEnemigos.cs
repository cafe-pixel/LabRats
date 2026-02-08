using System;
using System.Collections;
using UnityEngine;

public class SpawnerVidaDependienteEnemigos : MonoBehaviour
{
    [SerializeField] private int nEnemies;
    
    [Tooltip("ZonaDeTrigger")][SerializeField] private BoxCollider box;
    [Tooltip("BichitoTonto")][SerializeField] private BoxCollider boxMesh;
    [Tooltip("BichitoTonto")][SerializeField] private MeshRenderer mesh;
    [SerializeField] private Light pLight;
    
   


    private void Start()
    {
        
        //empieza con el trigger apagado, este se enciende cuando nEnemies es correcto
        mesh.enabled = false;
        boxMesh.enabled = false;
        pLight.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (nEnemies == EnemyCounter.instance.enemyCounter)
        {
            StartCoroutine(Encendido());

        }
    }
    
    private IEnumerator Encendido()
    {
        
        box.enabled = true;
        mesh.enabled = true;
        boxMesh.enabled = true;
        pLight.enabled = true;
        yield return new WaitForSeconds(25);
    }
}
