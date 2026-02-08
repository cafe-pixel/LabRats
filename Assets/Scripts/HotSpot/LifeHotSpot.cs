using System;
using UnityEngine;

public class LifeHotSpot : MonoBehaviour
{
    [SerializeField] private float lifeToGive;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        
    }
}
