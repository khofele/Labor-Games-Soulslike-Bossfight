using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSword : WeaponManager
{
    public void Start()
    {
        
    }

    //TODO: im Menü aufrufen damit Weapon-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        weaponType = "shortsword";
        weaponMinDmg = 50f;
    }
}
