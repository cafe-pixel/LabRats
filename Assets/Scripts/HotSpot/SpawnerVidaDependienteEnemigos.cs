using System;
using System.Collections;
using UnityEngine;

public class SpawnerVidaDependienteEnemigos : MonoBehaviour
{
    [SerializeField] private int nEnemies;

    private BoxCollider box;
    private BoxCollider boxMesh;
    private MeshRenderer mesh;
    private Light pLight;

    private bool activado = false;


    private void Awake()
    {
        foreach (var c in GetComponentsInChildren<BoxCollider>(true))
        {
            if (c.gameObject.name == "TriggerVidaDependienteEnemigo")
                box = c;

            else if (c.gameObject.name == "Hotspot")
                boxMesh = c;
        }
        foreach (var m in GetComponentsInChildren<MeshRenderer>(true))
        {
            if (m.gameObject.name == "Hotspot")
                mesh = m;
        }

        
        pLight = GetComponentInChildren<Light>(true);
    }
    private void Start()
    {
        if (mesh) mesh.enabled = false;
        if (boxMesh) boxMesh.enabled = false;
        if (pLight) pLight.enabled = false;
        if (box) box.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if ((!activado && nEnemies == EnemyCounter.instance.enemyCounter))
        {
            activado = true;
            StartCoroutine(Encendido());

        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    
    private IEnumerator Encendido()
    {
        Debug.Log("Estoy ejecutando la corrutina");
        
        
        if (mesh) mesh.enabled = true;
        if (boxMesh) boxMesh.enabled = true;
        if (pLight) pLight.enabled = true;
        
        yield return new WaitForSeconds(25);
    }
}
