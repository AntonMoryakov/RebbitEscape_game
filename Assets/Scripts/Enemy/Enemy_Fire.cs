// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Enemy_Fire : MonoBehaviour
// {
//     [SerializeField]
//     GameObject bullet;
//     public Transform firepoint;
//     public Transform point;
//     public float fireRate;
//     float nextFire;
//     public bool move = true;
//     Enemy_fire_platform patrol;
//     public Transform attackPoint;
//     public LayerMask enemyLayers;
//     public float attackRange = 0.5f;
//     void Start()
//     {
//         patrol = GameObject.FindObjectOfType<Enemy_fire_platform>();
//         nextFire = Time.time;
//         move = true;
//         firepoint = GameObject.FindWithTag("firepoint").transform;
//     }
    
//     private void Update()
//     {
//         Attack();
//     }

//     void Attack(){
//         Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(point.position, attackRange, enemyLayers);
//         foreach(Collider2D player in hitPlayer)
//         {
//             if(player.gameObject.CompareTag("Player")){
//                 Debug.Log("Box");
//                 move = false;
//                 Invoke("shoot", 0.4f);
//                 Invoke("Speed", 10f);
//             }
//         }
//     }
//     void OnDrawGizmosSelected()
//     {

//         Gizmos.DrawWireSphere(point.position, attackRange);
//     }

//     public void Speed()
//     {
//         move = true;
//     }
//     public void shoot()
//     {
//         //CancelInvoke("shoot");
//         if(Time.time > nextFire)
//         {
//             Instantiate(bullet, firepoint.position, Quaternion.identity);
//             nextFire = Time.time + fireRate;
//         }
//     }
// }
