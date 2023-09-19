using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerInteraction : MonoBehaviour
{
    public void Start()
    {
        hpText.text = "HP: " + ((int)health).ToString();
        
    }
    //public Collider2D other;
    public float health = 100f;
    public float maxHealth = 1000f;
    public Text hpText;
    //public Text MaxHpText;
    //public bool control = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("lite_Potion"))
        {
            ChangeHealth(5);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("elite_Potion"))
        {
            ChangeHealth(20);
            Destroy(other.gameObject);
        }
    }
    public void ChangeHealth(float healthValue)
    {   
        //if(health < 100)
        health += (healthValue);
        if(health > 100)
        {
            health = 100;    
        }
        //maxHealth += healthValue;
        UpdateHpText();
    }
    public void TakeDamage(int damage)
    {
        
        health -= damage;
        UpdateHpText();
        if (health <= 0)
        {
            Die();
        }
    }
    public void SetHealth(int bonusHealth)
    {   
        health += bonusHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void Die()
    {
        SceneManager.LoadScene(1);
    }
    void UpdateHpText()
    {
        hpText.text = "HP: " + ((int)health).ToString();
    }
}
