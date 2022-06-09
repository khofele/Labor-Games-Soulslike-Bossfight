using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IronArmor : Armor
{
    //used by the menu ItemManager when armor chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        armorName = "Ork Armor";
        armorType = ArmorTypeEnum.IRONARMOR;
        armorWeight = 40f;
        armorDef = 65f;
        helmetPrefab = Resources.Load("Character/Armors/IronArmor/IronArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/IronArmor/IronArmorTorso", typeof(Armor)) as Armor;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Start Run")
        {
            Start();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
