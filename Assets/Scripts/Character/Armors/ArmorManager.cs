using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorManager : MonoBehaviour
{
    //access to the CharController script
    protected CharController charController;
    //armor stats
    protected string armorName = ""; //name of the armor
    protected string armorType = ""; //type of armor
    protected float armorWeight = 0f; //weight of the armor
    protected float armorDef = 0f; //defense value of the armor

    // Start is called before the first frame update
    void Start()
    {
        charController = gameObject.GetComponentInParent<CharController>();
    }

    //--------------------------GETTER FOR DRAGON & CHAR-----------------------

    //TODO call in menu
    //called in menu to show armor name
    public string GetArmorName()
    {
        return armorName;
    }

    public string GetArmorType()
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
}

