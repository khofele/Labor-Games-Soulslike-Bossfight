using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClothArmor : Armor
{
    //used by the menu ItemManager when armor chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        armorName = "Elven Armor";
        armorType = ArmorTypeEnum.clotharmor;
        armorWeight = 15f;
        armorDef = 25f;
        helmetPrefab = Resources.Load("Character/Armors/ClothArmor/ClothArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/ClothArmor/ClothArmorTorso", typeof(Armor)) as Armor;
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
