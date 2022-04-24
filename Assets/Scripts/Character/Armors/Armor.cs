using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Armor : MonoBehaviour
{
    //access to the CharController script
    protected CharController charController;
    //armor stats
    protected string armorName = ""; //name of the armor
    protected string armorType = ""; //type of armor
    protected float armorWeight = 0f; //weight of the armor
    protected float armorDef = 0f; //defense value of the armor
    //armor prefabs
    protected GameObject helmetPrefab = null;
    protected GameObject torsoPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        charController = gameObject.GetComponentInParent<CharController>();
    }

    //method called by menu to set char controller prefabs of the chosen armor
    //TODO Aufruf Menü (SetCharacterPrefabs()) nach Reset()-Methode des Armor-Skripts
    public void SetCharacterPrefabs()
    {
        charController.SetArmorPrefabs(helmetPrefab, torsoPrefab);
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

