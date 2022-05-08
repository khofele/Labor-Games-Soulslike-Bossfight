using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeatherArmor : Armor
{
    //TODO: im Menü aufrufen damit Armor-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        armorName = "Ogar Armor"; 
        armorType = "leatherarmor";
        armorWeight = 20f;
        armorDef = 40f;
        helmetPrefab = Resources.Load("Character/Armors/LeatherArmor/LeatherArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/LeatherArmor/LeatherArmorTorso", typeof(Armor)) as Armor;
    }
}
