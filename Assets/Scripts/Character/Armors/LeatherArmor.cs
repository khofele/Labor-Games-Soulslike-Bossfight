using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeatherArmor : Armor
{
    //used by the menu ItemManager when armor chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        armorName = "Ogar Armor";
        armorType = ArmorTypeEnum.LEATHERARMOR;
        armorWeight = 20f;
        armorDef = 40f;
        helmetPrefab = Resources.Load("Character/Armors/LeatherArmor/LeatherArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/LeatherArmor/LeatherArmorTorso", typeof(Armor)) as Armor;
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
