using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
    public GameObject MenuPause;
    public bool juegoPausado = false;
    

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        MenuPause.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pausar()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

