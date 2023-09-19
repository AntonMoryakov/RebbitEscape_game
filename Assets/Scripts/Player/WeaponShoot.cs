using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 10;
    public Transform gun;
    public Transform gunTip;
    public float fireRate = 0.5f;
    private float timeBetweenShots = 0.0f;
    public float time;

    PlayerMovement xDir;
    PlayerCombat Weap;
    // Start is called before the first frame update
    void Start()
    {
        xDir = GetComponentInParent<PlayerMovement>();
        Weap = GetComponent<PlayerCombat>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > timeBetweenShots)
        { 
            //Debug.Log("ghj");
            Shoot();
        }
    }
    void Shoot()
    {
        PlayerCombat.GunHp -= 1;
        timeBetweenShots = Time.time + fireRate;
        GameObject bulletins = Instantiate(bullet, gunTip.position, gunTip.rotation);
        if(xDir.transform.localScale.x > 0)
        {
            bulletins.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletSpeed, 0f);
        }
        else
        {
            bulletins.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -bulletSpeed, 0f);
        }
        Destroy(bulletins, time);
        
    }
}
