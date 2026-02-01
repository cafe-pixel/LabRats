using System;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int nEnemies;
    private bool openDoor = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCounter>(out EnemyCounter enemyN))
        {
            if (enemyN.enemyCounter == nEnemies) openDoor = true;
            animator.SetBool("OpenDoor",true);
        }
    }
    
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<EnemyCounter>(out EnemyCounter enemyN))
        {
            if (enemyN.enemyCounter == nEnemies) openDoor = false;
            animator.SetBool("OpenDoor",false);
        }
    }
}
