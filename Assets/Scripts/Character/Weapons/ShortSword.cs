using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortsword : Weapon
{

    private void Start()
    {
        weaponType = "shortsword";
        weaponWeight = 10f;
        weaponMinDmg = 50f;
        weaponMaxDmg = 80f;
        weaponPrefab = Resources.Load("Character/Weapons/Shortsword", typeof(Weapon)) as Weapon;
    }

    //TODO: im Menü aufrufen damit Weapon-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        weaponType = "shortsword";
        weaponWeight = 10f;
        weaponMinDmg = 50f;
        weaponMaxDmg = 80f;
        weaponPrefab = Resources.Load("Character/Weapons/Shortsword", typeof(Weapon)) as Weapon;
    }
}
