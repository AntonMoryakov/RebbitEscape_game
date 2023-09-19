using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    //public Animator animator;
    //public GunChange gunChange;
    [Header("Ближний бой")]
    //public Collider2D attackMoment;
    public int weapon_hp = 40;
    public int damage = 5;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public Text Text;
    public bool attack;
    public bool equip;
    public float setTime;

    public GameObject[] weapons;

    [Header("weapons")]
    public GameObject[] guns;
    public static int GunHp = 40;
    public static GameObject gun;
    private float timeBetweenShots = 0.0f;
    public Text WeaponText;

    [Header("unlock_weapons")]
    public GameObject[] unlock_weapons;

    void Start()
    {   
        Text.text = "Need weapon";
        WeaponText.text = "Need weapon";
    }
    public void TIME()
    {
        equip = false;
    }
    private void Update()
    {
        for(int i = 0; i < unlock_weapons.Length;i++)
        {
            gun = unlock_weapons[i];
        }
        if(Input.GetButtonDown("Equip"))
        {
            Debug.Log("gghgg");
            equip = true;
        }
        if(Input.GetButtonUp("Equip"))
        {
            Debug.Log("gghgg");
            equip = false;
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            attack = true;
            Attack();
            if(((weapons[0].active == false) && (weapons[1].active == false) && (weapons[1].active == false) && (Time.time > nextAttackTime)))
            {
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if((weapons[0].active == true) && Time.time > nextAttackTime)
            {
                weapon_hp -= 1;
                UpdateWeapon();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if((weapons[1].active == true) && Time.time > nextAttackTime)
            {
                weapon_hp -= 1;
                UpdateWeapon();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if((weapons[2].active == true)) //&& Time.time > nextAttackTime)
            {
                weapon_hp -= 1;
                UpdateWeapon();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            attack = false;
        }


        else if(Input.GetButtonDown("Fire1") && Time.time > timeBetweenShots)
        { 
            if((guns[0].active == true))
            {
                
                UpdateWeapon_text();
            }
            if((guns[1].active == true))
            {
                UpdateWeapon_text();
            }
            if((guns[2].active == true))
            {
                UpdateWeapon_text();
            }
        }

        if(GunHp <= 0)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            WeaponText.text = "Need weapon";
        }


        if(weapon_hp <= 0)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            Text.text = "Need weapon";
        }
    }
    void Attack(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.gameObject.CompareTag("Box_lite")  && Time.time > nextAttackTime){
                Debug.Log("Box");
                enemy.GetComponent<box_hp_lite>().TakeDamage(damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if(enemy.gameObject.CompareTag("Box")  && Time.time > nextAttackTime){
                Debug.Log("Box");
                enemy.GetComponent<box_hp>().TakeDamage(damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if(enemy.gameObject.CompareTag("Enemy")  && Time.time > nextAttackTime){
                Debug.Log("enemy");
                enemy.GetComponent<Enemy>().TakeDamage(damage);
                nextAttackTime = Time.time + 1f / attackRate;
            }
            
        }
        
    }

    void OnTriggerStay2D(Collider2D attackMoment)
    {
    GameObject whatHit = attackMoment.gameObject;
        if(equip == true){
            if(whatHit.CompareTag("scrap"))
            {
                Text.text =  ((int)weapon_hp).ToString();
                Debug.Log("weapon");
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
                weapons[2].SetActive(false);
                damage = 20;
                weapon_hp = 20;
                
                unlock_weapons[0] = weapons[0];
            }
            else if(whatHit.CompareTag("chainsaw"))
            {
                Text.text =  ((int)weapon_hp).ToString();
                Debug.Log("chainsaw");
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
                weapons[2].SetActive(false);
                damage = 40;
                weapon_hp = 20;
                unlock_weapons[1] = weapons[1];
            }
            else if(whatHit.CompareTag("sewer_pipe"))
            {
                Text.text =  ((int)weapon_hp).ToString();
                Debug.Log("sewer_pipe");
                weapons[0].SetActive(false);
                weapons[1].SetActive(false);
                weapons[2].SetActive(true);
                damage = 30;
                weapon_hp = 20;
                unlock_weapons[2] = weapons[2];
            }
            else if(whatHit.CompareTag("weapon"))
            {
                Debug.Log("weapon");
                WeaponText.text =  ((int)GunHp).ToString();
                guns[0].SetActive(true);
                guns[1].SetActive(false);
                guns[2].SetActive(false);
                GunHp = 40;
                unlock_weapons[3] = guns[0];
        
            }
            else if(whatHit.CompareTag("weapon_2"))
            {
                Debug.Log("weapon_2");
                WeaponText.text =  ((int)GunHp).ToString();
                guns[0].SetActive(false);
                guns[1].SetActive(true);
                guns[2].SetActive(false);
                GunHp = 40;
                unlock_weapons[4] = guns[1];
            }
            else if(whatHit.CompareTag("weapon_3"))
            {
                Debug.Log("weapon_3");
                WeaponText.text =  ((int)GunHp).ToString();
                guns[0].SetActive(false);
                guns[1].SetActive(false);
                guns[2].SetActive(true);
                GunHp = 40;
                unlock_weapons[5] = guns[2];
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void UpdateWeapon()
    {
        Text.text =  ((int)weapon_hp).ToString();
    }
    void UpdateWeapon_text()
    {
        WeaponText.text =  ((int)GunHp).ToString();
    }
}
