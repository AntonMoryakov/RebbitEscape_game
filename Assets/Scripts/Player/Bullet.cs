using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 150;
    public Rigidbody2D rb;
    public int damage = 40;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Enemy enemy = hitinfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            Debug.Log("We shoot "+ enemy.name);
            enemy.TakeDamage_attak(damage);
            Destroy(gameObject);
        }
        box_hp box = hitinfo.GetComponent<box_hp>();
        if(box != null)
        {
            Debug.Log("We shoot "+ box.name);
            box.TakeDamage(damage);
            Destroy(gameObject);
        }
        box_hp_lite box_l = hitinfo.GetComponent<box_hp_lite>();
        if(box_l != null)
        {
            Debug.Log("We shoot "+ box_l.name);
            box_l.TakeDamage(damage);
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
