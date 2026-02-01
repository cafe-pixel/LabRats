using System;
using UnityEngine;

public class ItemHotSpot : MonoBehaviour
{
    //Se comunica con ataque de player
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private BoxCollider box;
    public bool canOpenDoorInTrigger;
    private AudioSource audiosrc;
    
    
    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        box.enabled = false;
        mesh.enabled = false;
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<WeaponShootPoint>(out WeaponShootPoint player))
        {
            player.NowCanShoot();
            mesh.enabled = true;
            box.enabled = true;
            canOpenDoorInTrigger = true;
            audiosrc.Play();
            
        }
    }
    
}
