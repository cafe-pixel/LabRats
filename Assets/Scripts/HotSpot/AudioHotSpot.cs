using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHotSpot : MonoBehaviour
{
  public AudioSource audiosrc;
  public AudioClip audioclip;

  private void OnTriggerEnter(Collider other)
  {
    audiosrc.PlayOneShot(audioclip);
    StartCoroutine(DestruirObjeto());

  }

  private IEnumerator DestruirObjeto()
  {
    yield return new WaitForSeconds(audiosrc.clip.length);
    Destroy(gameObject);
  }

  private void OnTriggerExit(Collider other)
  {
    audiosrc.Stop();
  }
}
