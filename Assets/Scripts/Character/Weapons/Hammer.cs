using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hammer : Weapon
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        weaponType = WeaponTypeEnum.HAMMER;
        weaponTypeHanded = WeaponTypeHandedEnum.TWOHAND;
        weaponWeight = 15f;
        weaponMinDmg = 70f;
        weaponMaxDmg = 100f;
        weaponPrefab = Resources.Load("Character/Weapons/Hammer", typeof(Weapon)) as Weapon;

        neededStaminaAttack01 = 28f;
        neededStaminaAttack02 = 28f;
        neededStaminaAttack03 = 28f;
        neededStaminaHeavyAttack = 43f;
        neededStaminaRoll = 63f;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Start Run")
        {
            Start();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
