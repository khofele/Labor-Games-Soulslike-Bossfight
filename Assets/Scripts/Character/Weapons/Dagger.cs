using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon 
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        weaponType = "daggers";
        weaponWeight = 10f;
        weaponMinDmg = 40f;
        weaponMaxDmg = 70f;
        weaponPrefab = Resources.Load("Character/Weapons/Dagger", typeof(Weapon)) as Weapon;
    }
}
