using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : Weapon
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        weaponType = WeaponTypeEnum.LANCE;
        weaponTypeHanded = WeaponTypeHandedEnum.ONEHAND;
        weaponWeight = 12f;
        weaponMinDmg = 65f;
        weaponMaxDmg = 95f;
        weaponPrefab = Resources.Load("Character/Weapons/Lance", typeof(Weapon)) as Weapon;
    }
}
