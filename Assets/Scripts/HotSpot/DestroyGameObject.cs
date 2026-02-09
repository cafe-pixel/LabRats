using System;
using TMPro;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField] private WeaponShootPoint shoot;
    [SerializeField] private MeshRenderer meshWeapon;
    [SerializeField] private TextMeshProUGUI mirilla;
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        shoot.canShoot = true;
        meshWeapon.enabled = true;
        mirilla.enabled = true;
        
        Destroy(gameObject);
    }
}
