using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    public int price = 0;
    public string weapon;
    [Header("Weapon Text")]
    public Text weapon_text_1;
    public Text weapon_text_2;
    public Text weapon_text_3;

    [Header("Price Text")]
    public Text price_text_1;
    public Text price_text_2;
    public Text price_text_3;
    private Transform player;
    public Transform shopItemTemplate;
    private int weapon_type;
    private int weapon_type_1;
    private int weapon_type_2;
    public List<GameObject> weapons_;
    //public PlayerCombat playerCombat;

    void Update()
    {
        for(int i = 0; i < weapons_.Count;i++)
        {
            if(PlayerCombat.gun != null)
            {
                weapons_.Add(PlayerCombat.gun);

            }
            else{i--;}
        }
    }
    private void Start()
    {
        container = GameObject.FindWithTag("container").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        container.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider2D)))
        {
            int i = 0;
            container.gameObject.SetActive(true);
            if(i < 1){
                weapon_type = Random.Range(1, 10);
                weapon_type_1 = Random.Range(1, 10);
                weapon_type_2 = Random.Range(1, 10);
                i++;
            }
            weapon_update();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            container.gameObject.SetActive(false);
        }
    }
    private void weapon_update()
    {
        switch (weapon_type)
        {
            case 1:
                weapon = "Pistol";
                Debug.Log("1");
                price = 30;
                shop_text_1();
                break;

            case 2:

                Debug.Log("Machine Gun");
                weapon = "Machine Gun";
                price = 60;
                shop_text_1();
                break;

            case 3:

                Debug.Log("Energy Rifle");
                weapon = "Energy Rifle";
                price = 90;
                shop_text_1();
                break;

            case 4:

                Debug.Log("RPG");
                weapon = "RPG";
                price = 120;
                shop_text_1();
                break;

            case 5:

                Debug.Log("Minigun");
                weapon = "Minigun";
                price = 150;
                shop_text_1();
                break;

            case 6:

                Debug.Log("Chainsaw");
                weapon = "Chainsaw";
                price = 180;
                shop_text_1();
                break;

            case 7:

                Debug.Log("Metal Pipe");
                weapon = "Metal Pipe";
                price = 210;
                shop_text_1();
                break;

            case 8:

                Debug.Log("Lightsaber");
                weapon = "Lightsaber";
                price = 240;
                shop_text_1();
                break;

            case 9:

                Debug.Log("Iron Tire");
                weapon = "Iron Tire";
                price = 270;
                shop_text_1();
                break;
        }
        switch (weapon_type_1)
        {
            case 1:
                weapon = "Pistol";
                Debug.Log("1");
                price = 30;
                shop_text_2();
                break;

            case 2:

                Debug.Log("Machine Gun");
                weapon = "Machine Gun";
                price = 60;
                shop_text_2();
                break;

            case 3:

                Debug.Log("Energy Rifle");
                weapon = "Energy Rifle";
                price = 90;
                shop_text_2();
                break;

            case 4:

                Debug.Log("RPG");
                weapon = "RPG";
                price = 120;
                shop_text_2();
                break;

            case 5:

                Debug.Log("Minigun");
                weapon = "Minigun5";
                price = 150;
                shop_text_2();
                break;

            case 6:

                Debug.Log("Chainsaw");
                weapon = "Chainsaw";
                price = 180;
                shop_text_2();
                break;

            case 7:

                Debug.Log("Metal Pipe");
                weapon = "Metal Pipe";
                price = 210;
                shop_text_2();
                break;

            case 8:

                Debug.Log("Lightsaber");
                weapon = "Lightsaber";
                price = 240;
                shop_text_2();
                break;

            case 9:

                Debug.Log("Iron Tire");
                weapon = "Iron Tire";
                price = 270;
                shop_text_2();
                break;
        }
        switch (weapon_type_2)
        {
            case 1:
                weapon = "Pistol";
                Debug.Log("1");
                price = 30;
                shop_text_3();
                break;

            case 2:

                Debug.Log("Machine Gun");
                weapon = "Machine Gun";
                price = 60;
                shop_text_3();
                break;

            case 3:

                Debug.Log("Energy Rifle");
                weapon = "Energy Rifle";
                price = 90;
                shop_text_3();
                break;

            case 4:

                Debug.Log("RPG");
                weapon = "RPG";
                price = 120;
                shop_text_3();
                break;

            case 5:

                Debug.Log("Minigun");
                weapon = "Minigun";
                price = 150;
                shop_text_3();
                break;

            case 6:

                Debug.Log("Chainsaw");
                weapon = "Chainsaw";
                price = 180;
                shop_text_3();
                break;

            case 7:

                Debug.Log("Metal Pipe");
                weapon = "Metal Pipe";
                price = 210;
                shop_text_3();
                break;

            case 8:

                Debug.Log("Lightsaber");
                weapon = "Lightsaber";
                price = 240;
                shop_text_3();
                break;

            case 9:

                Debug.Log("Iron Tire");
                weapon = "Iron Tire";
                price = 270;
                shop_text_3();
                break;
        }
    }

    void shop_text_1()
    {   
        price_text_1.text = ((int)price).ToString();
        weapon_text_1.text = ((string)weapon);
    }
    void shop_text_2()
    {   
        price_text_2.text = ((int)price).ToString();
        weapon_text_2.text = ((string)weapon);
    }
    void shop_text_3()
    {   
        price_text_3.text = ((int)price).ToString();
        weapon_text_3.text = ((string)weapon);
    }
    // void UpdateWeapon_text()
    // {
    //     WeaponText.text =  ((int)GunHp).ToString();
    // }
}
