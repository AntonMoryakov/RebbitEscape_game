using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 150f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool faceright = true;
    public Vector2 moveVector;
    public int lungeImpulse = 10000;
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Lunge()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("ghjk");
            if (moveVector.x != 0)
            {
                rb.AddForce(transform.right * lungeImpulse);
                Physics2D.IgnoreLayerCollision(6, 7, true);
                Physics2D.IgnoreLayerCollision(6, 12, true);
                crouch = true;
                Invoke("IgnoreLayerOff_1", 0.5f);
            }
            else
            {
                rb.AddForce(transform.right * lungeImpulse);
                Physics2D.IgnoreLayerCollision(6, 7, true);
                Physics2D.IgnoreLayerCollision(6, 12, true);
                crouch = true;
                Invoke("IgnoreLayerOff_1", 0.5f);
            }
        }
    }
    void Update()
    {
        Lunge();
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if ((moveVector.y > 0) || (moveVector.y < 0 && faceright))
        {
            faceright = !faceright;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Physics2D.IgnoreLayerCollision(6, 8, true);           
            Invoke("IgnoreLayerOff", 0.2f);
        }
        else if (Input.GetButtonUp("Crouch"))
        {    
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }

    void IgnoreLayerOff_1()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
        Physics2D.IgnoreLayerCollision(6, 12, false);
        crouch = false;
    }

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}
