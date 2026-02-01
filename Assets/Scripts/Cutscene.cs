using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
   void OnEnable()
   {
      SceneManager.LoadScene("Escena1", LoadSceneMode.Single);
   }
}
