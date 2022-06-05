using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothArmor : Armor
{
    //used by the menu ItemManager when armor chosen
    private void Start()
    {
        armorName = "Elven Armor";
        armorType = "clotharmor";
        armorWeight = 15f;
        armorDef = 25f;
        helmetPrefab = Resources.Load("Character/Armors/ClothArmor/ClothArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/ClothArmor/ClothArmorTorso", typeof(Armor)) as Armor;
    }
}
