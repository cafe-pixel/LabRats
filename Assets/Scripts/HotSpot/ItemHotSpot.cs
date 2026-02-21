using System;
using UnityEngine;


public class ItemHotSpot : MonoBehaviour
{
    //Se comunica con ataque de player
    private bool musicOff = false;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private BoxCollider box;
    private AudioSource audiosrc;
    [SerializeField] private Light light;
    
    
    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        box.enabled = false;
        Debug.Log("Comienzo con los elementos apagados");
        mesh.enabled = false;
        light.enabled = false;
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<WeaponShootPoint>(out WeaponShootPoint player) && !musicOff)
        {
            player.NowCanShoot();
            mesh.enabled = true;
            Debug.Log("Enciendo los elementos");
            box.enabled = true;
            light.enabled = true;
            musicOff = true;
            player.NowCanOpenFirstDoor();
            audiosrc.Play();
            
        }
    }
    
}