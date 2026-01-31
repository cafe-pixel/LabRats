using System;
using UnityEngine;

public class MusicHotSpot : MonoBehaviour
{
    private AudioSource audiosrc;

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audiosrc.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        audiosrc.Stop();
    }
}
