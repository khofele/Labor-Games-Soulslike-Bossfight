using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronArmor : Armor
{
    //used by the menu ItemManager when armor chosen
    private void Start()
    {
        armorName = "Ork Armor";
        armorType = ArmorTypeEnum.ironarmor;
        armorWeight = 40f;
        armorDef = 65f;
        helmetPrefab = Resources.Load("Character/Armors/IronArmor/IronArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/IronArmor/IronArmorTorso", typeof(Armor)) as Armor;
    }
}
