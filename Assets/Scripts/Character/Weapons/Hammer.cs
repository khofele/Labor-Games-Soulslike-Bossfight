using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        weaponType = WeaponTypeEnum.HAMMER;
        weaponTypeHanded = WeaponTypeHandedEnum.TWOHAND;
        weaponWeight = 15f;
        weaponMinDmg = 70f;
        weaponMaxDmg = 100f;
        weaponPrefab = Resources.Load("Character/Weapons/Hammer", typeof(Weapon)) as Weapon;
    }
}
