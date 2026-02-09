using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHotSpot : MonoBehaviour
{
  public AudioSource audiosrc;
  public AudioClip audioclip;

  [SerializeField] private Light pLight;

  [SerializeField] private PlayerMovement move;

  [SerializeField] private float lifeToGive;

  

  private void Start()
  {

  }




  private void OnTriggerEnter(Collider other)
  {

    if (other.TryGetComponent<PlayerLife>(out PlayerLife player))
    {
      move.enabled = false;
      audiosrc.PlayOneShot(audioclip);
      StartCoroutine(DestruirObjeto());
      Debug.Log("TriggerDEPlayer");
      player.GiveYouLife(lifeToGive);
      
      

    }
    
    


  }

  private IEnumerator DestruirObjeto()
  {
    yield return new WaitForSeconds(audiosrc.clip.length);
    pLight.enabled = false;
    move.enabled = true;
    var spawner = GetComponentInParent<SpawnerVidaDependienteEnemigos>();
    if (spawner != null)
      spawner.enabled = false;
    Destroy(gameObject);
  }
}

  
  




