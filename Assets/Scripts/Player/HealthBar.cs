using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Image Vida;
    public float vidaActual;
    public float vidaMaxima;
    public float CantidadCuracionItem;

    //public float fillPerClick = 0.2f; 

    void Update()
    {
        Vida.fillAmount = vidaActual / vidaMaxima;
            
        /*if (vidaActual <= 0)
        {
            //SceneManager.LoadScene(2);
        }*/
    }

    public void RecibirDanoDeEnemigo()
    {
        vidaActual--;
    }

    
    //por si le metemos curación
    public void AumentarVida()
    {
        vidaActual += CantidadCuracionItem;
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
    }
}

