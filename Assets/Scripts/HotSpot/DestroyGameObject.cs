using System;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
