using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shortsword : Weapon
{
    //used by the menu ItemManager when weapon chosen
    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;

        weaponType = WeaponTypeEnum.SHORTSWORD;
        weaponTypeHanded = WeaponTypeHandedEnum.ONEHAND;
        weaponWeight = 10f;
        weaponMinDmg = 50f;
        weaponMaxDmg = 80f;
        weaponPrefab = Resources.Load("Character/Weapons/Shortsword", typeof(Weapon)) as Weapon;

        neededStaminaAttack01 = 25f;
        neededStaminaAttack02 = 25f;
        neededStaminaAttack03 = 25f;
        neededStaminaHeavyAttack = 40f;
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
