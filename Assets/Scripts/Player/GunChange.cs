// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class GunChange : MonoBehaviour
// {
//     public GameObject[] guns;
//     public PlayerCombat playerCombat;
//     public bool equip;
//     public static int GunHp = 40;
//     private float timeBetweenShots = 0.0f;
//     public Text WeaponText;
//     public void Start()
//     {
//         WeaponText.text = "Need weapon";
        
//     }
//     private void Update()
//     {
//         if(Input.GetButtonDown("Equip"))
//         {
//             Debug.Log("gghgg");
//             equip = true;
//         }
//         else if(Input.GetButtonUp("Equip"))
//         {
//             Debug.Log("23456789");
//             equip = false;
//         }
//         if(Input.GetButtonDown("Fire1") && Time.time > timeBetweenShots)
//         { 
//             if((guns[0].active == true))
//             {
//                 UpdateWeapon();
//             }
//             if((guns[1].active == true))
//             {
//                 UpdateWeapon();
//             }
//             if((guns[2].active == true))
//             {
//                 UpdateWeapon();
//             }
//         }
//         if(GunHp <= 0)
//         {
//             guns[0].SetActive(false);
//             guns[1].SetActive(false);
//             guns[2].SetActive(false);
//             WeaponText.text = "Need weapon";
//         }
//     }
//     private void OnTriggerStay2D(Collider2D col)
//     {
//         GameObject whatHit = col.gameObject;
//         if(equip == true){
//             if(whatHit.CompareTag("weapon"))
//             {
//                 Debug.Log("weapon");
//                 WeaponText.text =  ((int)GunHp).ToString();
//                 guns[0].SetActive(true);
//                 guns[1].SetActive(false);
//                 guns[2].SetActive(false);
//                 GunHp = 40;
//                 playerCombat.unlock_weapons[3] = guns[0];
//             }
//             if(whatHit.CompareTag("weapon_2"))
//             {
//                 Debug.Log("weapon_2");
//                 WeaponText.text =  ((int)GunHp).ToString();
//                 guns[0].SetActive(false);
//                 guns[1].SetActive(true);
//                 guns[2].SetActive(false);
//                 GunHp = 40;
//             }
//             if(whatHit.CompareTag("weapon_3"))
//             {
//                 Debug.Log("weapon_3");
//                 WeaponText.text =  ((int)GunHp).ToString();
//                 guns[0].SetActive(false);
//                 guns[1].SetActive(false);
//                 guns[2].SetActive(true);
//                 GunHp = 40;
//             }
//         }
//     }
//     void UpdateWeapon()
//     {
//         WeaponText.text =  ((int)GunHp).ToString();
//     }
// }
