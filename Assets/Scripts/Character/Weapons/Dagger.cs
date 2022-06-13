using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dagger : Weapon 
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        weaponType = WeaponTypeEnum.DAGGERS;
        weaponTypeHanded = WeaponTypeHandedEnum.BOTH;
        weaponWeight = 10f;
        weaponMinDmg = 40f;
        weaponMaxDmg = 70f;
        weaponPrefab = Resources.Load("Character/Weapons/Dagger", typeof(Weapon)) as Weapon;

        neededStaminaAttack01 = 20f;
        neededStaminaAttack02 = 20f;
        neededStaminaAttack03 = 20f;
        neededStaminaHeavyAttack = 35f;
        neededStaminaRoll = 60f;
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
