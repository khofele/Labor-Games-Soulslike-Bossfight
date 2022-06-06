using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateArmor : Armor
{
    //used by the menu ItemManager when armor chosen
    private void Start()
    {
        armorName = "Plate Armor";
        armorType = ArmorTypeEnum.platearmor;
        armorWeight = 35f;
        armorDef = 58f;
        helmetPrefab = Resources.Load("Character/Armors/PlateArmor/PlateArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/PlateArmor/PlateArmorTorso", typeof(Armor)) as Armor;
    }
}
