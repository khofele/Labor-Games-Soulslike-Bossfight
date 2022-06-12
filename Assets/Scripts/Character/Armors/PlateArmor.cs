using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlateArmor : Armor
{
    //used by the menu ItemManager when armor chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        armorName = "Plate Armor";
        armorType = ArmorTypeEnum.PLATEARMOR;
        armorWeight = 33f;
        armorDef = 58f;
        helmetPrefab = Resources.Load("Character/Armors/PlateArmor/PlateArmorHelmet", typeof(Armor)) as Armor;
        torsoPrefab = Resources.Load("Character/Armors/PlateArmor/PlateArmorTorso", typeof(Armor)) as Armor;
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
