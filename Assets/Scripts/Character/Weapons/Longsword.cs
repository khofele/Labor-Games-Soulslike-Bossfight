using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longsword : Weapon
{
    private void Start()
    {
        weaponWeight = 15f;
    }

    //TODO: im Menü aufrufen damit Weapon-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        weaponType = "longsword";
        weaponWeight = 15f;
        weaponMinDmg = 75f;
        weaponMaxDmg = 105f;
        weaponPrefab = Resources.Load("Character/Weapons/Longword", typeof(Weapon)) as Weapon;
    }
}
