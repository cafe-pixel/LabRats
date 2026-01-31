using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamagable
{
    [SerializeField] private float lifeCounterMax;
    public float lifeCounter;
    //[SerializeField] private HealthBar healthBar;
    private PlayerMovement move;
    
    public HealthBar healthBarScript;
    public GameObject GameOverCanvas;
    public GameObject GamePauseCanvas;

    private void Awake()
    {
        move = GetComponent<PlayerMovement>();
        lifeCounter = lifeCounterMax;

    }
    
    public void MakeDamage(float damage, GameObject damagedealer)
    {
        lifeCounter -= damage;
        healthBarScript.RecibirDanoDeEnemigo();
        Vector3 knockDirection = this.transform.position - damagedealer.transform.position;
        move.Knockback(knockDirection,damage);
        if (lifeCounter <= 0)
        {
            GameOverCanvas.SetActive(true);
            Time.timeScale = 0;
            Destroy(GamePauseCanvas);
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            MakeDamage(10, gameObject);
        }
    }*/

    public void GiveYouLife(float life)
    {
        lifeCounter += life;
        if (lifeCounter > lifeCounterMax) lifeCounter = lifeCounterMax;
    }

    
}
