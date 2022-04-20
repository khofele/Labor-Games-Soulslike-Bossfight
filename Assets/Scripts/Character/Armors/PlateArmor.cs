using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateArmor : ArmorManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TODO: im Menü aufrufen damit Armor-Werte gesetzt - MUSS AUFGERUFEN WERDEN
    // Overwrites the values in the parent class when called
    public void Reset()
    {
        armorName = "Plate Armor";
        armorType = "platearmor";
        armorWeight = 35f;
        armorDef = 58f;
        helmetPrefab = Resources.Load("Character/Armors/PlateArmor/PlateArmorHelmet", typeof(GameObject)) as GameObject;
        torsoPrefab = Resources.Load("Character/Armors/PlateArmor/PlateArmorTorso", typeof(GameObject)) as GameObject;
    }
}
