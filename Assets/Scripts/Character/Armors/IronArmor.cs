using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronArmor : ArmorManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TODO: im Men� aufrufen damit Armor-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        armorName = "Ork Armor";
        armorType = "ironarmor";
        armorWeight = 40f;
        armorDef = 65f;
    }
}
