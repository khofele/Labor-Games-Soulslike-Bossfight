using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Longsword : Weapon
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        weaponType = WeaponTypeEnum.LONGSWORD;
        weaponTypeHanded = WeaponTypeHandedEnum.TWOHAND;
        weaponWeight = 15f;
        weaponMinDmg = 75f;
        weaponMaxDmg = 105f;
        weaponPrefab = Resources.Load("Character/Weapons/Longsword", typeof(Weapon)) as Weapon;

        neededStaminaAttack01 = 28f;
        neededStaminaAttack02 = 28f;
        neededStaminaAttack03 = 28f;
        neededStaminaHeavyAttack = 43f;
        neededStaminaRoll = 62f;
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
