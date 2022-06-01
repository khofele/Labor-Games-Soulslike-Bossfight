using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothArmor : Armor
{
    private void Start()
    {
        armorType = "clotharmor";
    }

    //TODO: im Menü aufrufen damit Armor-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        armorName = "Elven Armor";
        armorType = "clotharmor";
        armorWeight = 15f;
        armorDef = 25f;
        helmetPrefab = Resources.Load("Character/Armors/ClothArmor/ClothArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/ClothArmor/ClothArmorTorso", typeof(Armor)) as Armor;
    }
}
