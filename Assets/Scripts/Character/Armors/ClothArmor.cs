using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothArmor : ArmorManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TODO: im Menü aufrufen damit Armor-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        armorName = "Elven Armor";
        armorType = "clotharmor";
        armorWeight = 10f;
        armorDef = 25f;
        helmetPrefab = Resources.Load("Armors/ClothArmor/ClothArmorHelmet", typeof(GameObject)) as GameObject;
        torsoPrefab = Resources.Load("Armors/ClothArmor/ClothArmorTorso", typeof(GameObject)) as GameObject;
    }
}
