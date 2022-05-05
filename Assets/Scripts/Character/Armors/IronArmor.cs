using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronArmor : Armor
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TODO: im Menü aufrufen damit Armor-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        armorName = "Ork Armor";
        armorType = "ironarmor";
        armorWeight = 40f;
        armorDef = 65f;
        helmetPrefab = Resources.Load("Character/Armors/IronArmor/IronArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/IronArmor/IronArmorTorso", typeof(Armor)) as Armor;
    }
}
