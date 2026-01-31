using UnityEngine;

public class GroundCol : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            player.canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Path"))
        {
            player.canJump = false;
        }
    }
}
