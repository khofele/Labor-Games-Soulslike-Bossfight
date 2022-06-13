using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lance : Weapon
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        weaponType = WeaponTypeEnum.LANCE;
        weaponTypeHanded = WeaponTypeHandedEnum.ONEHAND;
        weaponWeight = 12f;
        weaponMinDmg = 65f;
        weaponMaxDmg = 95f;
        weaponPrefab = Resources.Load("Character/Weapons/Lance", typeof(Weapon)) as Weapon;

        neededStaminaAttack01 = 30f;
        neededStaminaHeavyAttack = 45f;
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
