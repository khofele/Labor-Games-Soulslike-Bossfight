using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longsword : Weapon
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        weaponType = WeaponTypeEnum.longsword;
        weaponTypeHanded = WeaponTypeHandedEnum.twohand;
        weaponWeight = 15f;
        weaponMinDmg = 75f;
        weaponMaxDmg = 105f;
        weaponPrefab = Resources.Load("Character/Weapons/Longsword", typeof(Weapon)) as Weapon;
    }
}
