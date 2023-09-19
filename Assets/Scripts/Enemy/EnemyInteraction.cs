using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public int damage = 20;
    float nextAttackTime = 0f;
    public float attackRate = 4f;
    public int control;
    //private Transform player;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (Time.time >= nextAttackTime)
            {
                Debug.Log("CTRL");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        void Attack()
        {
            other.GetComponent<PlayerInteraction>().TakeDamage(damage);
        }
    }
}
