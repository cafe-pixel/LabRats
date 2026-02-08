using System;
using UnityEngine;

public class LifeHotSpot : MonoBehaviour
{
    [SerializeField] private float lifeToGive;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.TryGetComponent<PlayerLife>(out PlayerLife player))
        {
            Debug.Log("TriggerDEPlayer");
            player.GiveYouLife(lifeToGive);
        }
    }
}
