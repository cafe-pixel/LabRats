using System;
using UnityEngine;

public class ItemHotSpot : MonoBehaviour
{
    //Se comunica con ataque de player
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<WeaponShootPoint>(out WeaponShootPoint player))
        {
            player.NowCanShoot();
        }
    }
}
