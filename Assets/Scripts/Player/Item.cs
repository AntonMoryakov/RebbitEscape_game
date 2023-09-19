using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        WeaponNone,
        Weapon_1,
        Weapon_2,
        Weapon_3,
        Weapon_4,
        Weapon_5,
        Weapon_6,
        Weapon_7,
        Weapon_8,
        Weapon_9,
    }

    public static int GetCost(ItemType itemType)
    {
        switch(itemType)
        {
        default:
        case ItemType.WeaponNone: return 0;
        case ItemType.Weapon_1: return 20;
        case ItemType.Weapon_2: return 80;
        case ItemType.Weapon_3: return 140;
        case ItemType.Weapon_4: return 200;
        case ItemType.Weapon_5: return 260;
        case ItemType.Weapon_6: return 320;
        case ItemType.Weapon_7: return 380;
        case ItemType.Weapon_8: return 440;
        case ItemType.Weapon_9: return 500;
        }
    }
}
