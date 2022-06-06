using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon 
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        weaponType = WeaponTypeEnum.daggers;
        weaponTypeHanded = WeaponTypeHandedEnum.onehand;
        weaponWeight = 10f;
        weaponMinDmg = 40f;
        weaponMaxDmg = 70f;
        weaponPrefab = Resources.Load("Character/Weapons/Dagger", typeof(Weapon)) as Weapon;
    }
}
