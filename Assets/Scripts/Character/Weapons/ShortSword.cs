using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortsword : Weapon
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        weaponType = "shortsword";
        weaponWeight = 10f;
        weaponMinDmg = 50f;
        weaponMaxDmg = 80f;
        weaponPrefab = Resources.Load("Character/Weapons/Shortsword", typeof(Weapon)) as Weapon;
    }
}
