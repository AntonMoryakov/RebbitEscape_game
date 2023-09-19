using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_hp : MonoBehaviour
{
    public int health = 40;
    public GameObject apt;
    public Transform aptpoint;
    public Transform aptpoint_1;
    //public Transform aptpoint_2;

    public void Start()
    {
       apt = GameObject.FindGameObjectWithTag("elite_Potion");
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        med();
        Destroy(gameObject);
    }
    void med()
    {
        Instantiate(apt, aptpoint.position, aptpoint.rotation);
        Instantiate(apt, aptpoint_1.position, aptpoint_1.rotation);
        // Instantiate(apt, aptpoint_2.position, aptpoint_2.rotation);
    }
}
