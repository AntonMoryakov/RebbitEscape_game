using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_fire_platform : MonoBehaviour
{
    [Header("move")]
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

    [Header("attack")]
    public GameObject bullet;
    public Transform firepoint;
    public Transform point;
    public float fireRate;
    float nextFire;
    private bool move = true;
    Enemy_fire_platform patrol;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;

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
        Attack();
        if(move == true){
            speed = 5.87f;
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
        else if(move == false){
            speed = 0f;
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
    private void Attack(){
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(point.position, attackRange, enemyLayers);
        foreach(Collider2D player in hitPlayer)
        {
            if(player.gameObject.CompareTag("Player")){
                //Debug.Log("Box");
                move = false;
                Invoke("shoot", 0.4f);
                Invoke("Speed", 10f);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point.position, attackRange);
    }

    private void Speed()
    {
        move = true;
    }
    private void shoot()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, firepoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}