using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enemy : MonoBehaviour
{
    public float moveSpeed = 7f;
    Rigidbody2D rb;
    PlayerMovement target;
    Vector2 moveDirection;
    public int damage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInteraction player = other.GetComponent<PlayerInteraction>();
        if(player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Physics2D.IgnoreLayerCollision(7, 13, true);
    }
}
