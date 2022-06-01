using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : Weapon
{
    private void Start()
    {
        weaponWeight = 12f;
    }

    //TODO: im Menü aufrufen damit Weapon-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        weaponType = "lance";
        weaponWeight = 12f;
        weaponMinDmg = 65f;
        weaponMaxDmg = 95f;
        weaponPrefab = Resources.Load("Character/Weapons/Lance", typeof(Weapon)) as Weapon;
    }
}
