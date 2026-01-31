using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour, IDamagable
{
    [SerializeField] private float lifeCounter;
    //[SerializeField] private HealthBar healthBar;
    private PlayerMovement move;
    
    public HealthBar healthBarScript;

    private void Awake()
    {
        move = GetComponent<PlayerMovement>();
        
    }
    
    public void MakeDamage(float damage, GameObject damagedealer)
    {
        lifeCounter -= damage;
        healthBarScript.RecibirDanoDeEnemigo();
        Vector3 knockDirection = this.transform.position - damagedealer.transform.position;
        move.Knockback(knockDirection,damage);
        if (lifeCounter == 0) Destroy(gameObject);
    }

    
}
