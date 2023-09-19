using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Physics2D.IgnoreLayerCollision(7, 6, true);
    public int health = 100;
    public EnemyHealthBar healthBar;
    //public int maxHealth;

    void Start()
    {
        healthBar.SetHealth(health);
        //maxHealth = health;
    }

    public void TakeDamage(int damage)
    {
        healthBar.SetHealth(health);
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void TakeDamage_attak(int damage_f)
    {
        healthBar.SetHealth(health);
        health -= damage_f;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
