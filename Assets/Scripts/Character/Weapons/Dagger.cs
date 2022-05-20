using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Weapon 
{

    //TODO: im Menü aufrufen damit Weapon-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        weaponType = "daggers";
        weaponWeight = 10f;
        weaponMinDmg = 40f;
        weaponMaxDmg = 70f;
        weaponPrefab = Resources.Load("Character/Weapons/Dagger", typeof(Weapon)) as Weapon;
    }
}
