using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateArmor : Armor
{
    private void Start()
    {
        this.armorWeight = 35f;
        this.armorDef = 58f;
    }

    //TODO: im Menü aufrufen damit Armor-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        armorName = "Plate Armor";
        armorType = "platearmor";
        armorWeight = 35f;
        armorDef = 58f;
        helmetPrefab = Resources.Load("Character/Armors/PlateArmor/PlateArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/PlateArmor/PlateArmorTorso", typeof(Armor)) as Armor;
    }
}
