using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private PlayerMovement playerMovement;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    
}
