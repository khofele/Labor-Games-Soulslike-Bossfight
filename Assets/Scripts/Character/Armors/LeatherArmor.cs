using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeatherArmor : Armor
{
    //used by the menu ItemManager when armor chosen
    private void Start()
    {
        armorName = "Ogar Armor";
        armorType = ArmorTypeEnum.LEATHERARMOR;
        armorWeight = 20f;
        armorDef = 40f;
        helmetPrefab = Resources.Load("Character/Armors/LeatherArmor/LeatherArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/LeatherArmor/LeatherArmorTorso", typeof(Armor)) as Armor;
    }
}
