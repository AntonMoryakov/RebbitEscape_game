using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;
    public Transform enemy_pos;
    public Transform zone;
    private Transform player_pos;
    public Transform back;
    private Transform position_;
    
    public LayerMask walls;
    public Transform groundDetection;
    public Transform wallDetection;

    void Update()
    {
        Physics2D.IgnoreLayerCollision(7, 9, true);
        player_pos = GameObject.FindWithTag("Player").transform;
        position_ = GameObject.FindWithTag("Player").transform;
        int layerMask_wall = LayerMask.GetMask("Ground");
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, distance, layerMask_wall);

        if (groundInfo.collider == false || wallInfo.collider == true)
        {
            if (movingRight == true)
            {

                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = false;
                

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;

            }
        }
    }
    void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(7, 7, true);
        if (movingRight == true)  //движется вправо
        {
            if ((position_.position.x >= enemy_pos.position.x) && (position_.position.x < zone.position.x) && (player_pos.position.y > enemy_pos.position.y - 0.193) && (player_pos.position.y < enemy_pos.position.y + 0.193))
            {
                transform.position = Vector2.MoveTowards(transform.position, position_.position, speed * Time.deltaTime);
            }
            else
            {
                if ((position_.position.x <= enemy_pos.position.x) && (position_.position.x > back.position.x) && (player_pos.position.y > enemy_pos.position.y - 0.193) && (player_pos.position.y < enemy_pos.position.y + 0.193))
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    transform.position = Vector2.MoveTowards(transform.position, position_.position, speed * Time.deltaTime);
                    movingRight = false;
                }
                else if ((position_.position.x > enemy_pos.position.x) && (position_.position.x < back.position.x) && (player_pos.position.y > enemy_pos.position.y - 0.193) && (player_pos.position.y < enemy_pos.position.y + 0.193))
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    transform.position = Vector2.MoveTowards(transform.position, position_.position, speed * Time.deltaTime);
                }
            }
        }
        else //движется влево
        {
            if ((position_.position.x <= enemy_pos.position.x) && (position_.position.x > zone.position.x) && (player_pos.position.y > enemy_pos.position.y - 0.193) && (player_pos.position.y < enemy_pos.position.y + 0.193))
            {
                transform.position = Vector2.MoveTowards(transform.position, position_.position, speed * Time.deltaTime);
            }
            else
            {
                if ((position_.position.x >= enemy_pos.position.x) && (position_.position.x < back.position.x) && (player_pos.position.y > enemy_pos.position.y - 0.193) && (player_pos.position.y < enemy_pos.position.y + 0.193))
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    transform.position = Vector2.MoveTowards(transform.position, position_.position, speed * Time.deltaTime);
                    movingRight = true;
                }
                else if((position_.position.x < enemy_pos.position.x) && (position_.position.x > back.position.x) && (player_pos.position.y > enemy_pos.position.y - 0.193) && (player_pos.position.y < enemy_pos.position.y + 0.193))
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    transform.position = Vector2.MoveTowards(transform.position, position_.position, speed * Time.deltaTime);
                }
            }
        }
    }
}
