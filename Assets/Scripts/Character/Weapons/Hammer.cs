using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    private void Start()
    {
        weaponType = "hammer";
        weaponWeight = 15f;
        weaponMinDmg = 70f;
        weaponMaxDmg = 100f;
        weaponPrefab = Resources.Load("Character/Weapons/Hammer", typeof(Weapon)) as Weapon;
    }

    //TODO: im Menü aufrufen damit Weapon-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        weaponType = "hammer";
        weaponWeight = 15f;
        weaponMinDmg = 70f;
        weaponMaxDmg = 100f;
        weaponPrefab = Resources.Load("Character/Weapons/Hammer", typeof(Weapon)) as Weapon;
    }
}
