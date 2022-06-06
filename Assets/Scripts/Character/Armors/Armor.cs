using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorTypeEnum
{
    clotharmor, leatherarmor, ironarmor, platearmor
}

public abstract class Armor : MonoBehaviour
{
    //access to the CharController script
    protected CharController charController;
    //armor stat fields
    protected string armorName = ""; //name of the armor
    protected ArmorTypeEnum armorType; //type of armor
    protected float armorWeight = 0f; //weight of the armor
    protected float armorDef = 0f; //defense value of the armor
    //armor prefab fields
    protected Armor helmetPrefab = null;
    protected Armor torsoPrefab = null;

    // Start is called before the first frame update
    private void Start()
    {
        charController = gameObject.GetComponentInParent<CharController>();
    }

    //--------------------------GETTER FOR DRAGON, CHAR AND MENU-----------------------

    //called in menu (ItemManager) to show armor name
    public string GetArmorName()
    {
        return armorName;
    }

    public ArmorTypeEnum GetArmorType()
    {
        return armorType;
    }

    public float GetArmorWeight()
    {
        return armorWeight;
    }

    public float GetArmorDef()
    {
        return armorDef;
    }

    public Armor GetTorsoArmorPrefab()
    {
        return torsoPrefab;
    }

    public Armor GetHelmetPrefab()
    {
        return helmetPrefab;
    }
}

