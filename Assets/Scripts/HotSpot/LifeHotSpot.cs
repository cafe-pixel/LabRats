using System;
using UnityEngine;

public class LifeHotSpot : MonoBehaviour
{
    [SerializeField] private float lifeToGive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerLife>(out PlayerLife player))
        {
            player.GiveYouLife(lifeToGive);
        }
    }
}
