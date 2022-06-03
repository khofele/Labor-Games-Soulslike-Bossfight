using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private AttributeManager attributeManager = null;
    [SerializeField] private StartRunMenuUIManager uiManager = null;

    [Header("Armor")]
    [SerializeField] private ClothArmor clothArmor = null;
    [SerializeField] private IronArmor ironArmor = null;
    [SerializeField] private LeatherArmor leatherArmor = null;
    [SerializeField] private PlateArmor plateArmor = null;

    [Header("Weapons")]
    [SerializeField] private Shortsword shortSword = null;
    [SerializeField] private Longsword longSword = null;
    [SerializeField] private Dagger dagger = null;
    [SerializeField] private Hammer hammer = null;
    [SerializeField] private Lance lance = null;

    private static ItemManager instance = null;

    private Weapon currentWeapon = null;
    private string currentWeaponType = "";
    private float currentWeaponWeight = 0f;
    private float currentWeaponMinDmg = 0f;
    private float currentWeaponMaxDmg = 0f;
    private Weapon currentWeaponPrefab = null;
    private RuntimeAnimatorController currentWeaponAC = null;

    private Armor currentArmor = null;
    private string currentArmorName = "";
    private string currentArmorType = "";
    private float currentArmorWeight = 0f;
    private float currentArmorDef = 0f;
    private Armor currentTorsoArmorPrefab = null;
    private Armor currentHelmetPrefab = null;

    private int potionCount = 5;

    public int PotionCount { get => potionCount; }

    public Weapon CurrentWeapon { get => currentWeapon; }
    public string CurrentWeaponType { get => currentWeaponType; }
    public float CurrentWeaponWeight { get => currentWeaponWeight; }
    public float CurrentWeaponMinDmg { get => currentWeaponMinDmg; }
    public float CurrentWeaponMaxDmg { get => currentWeaponMaxDmg; }
    public Weapon CurrentWeaponPrefab { get => currentWeaponPrefab; }

    public Armor CurrentArmor { get => currentArmor; }
    public string CurrentArmorName { get => currentArmorName; }
    public string CurrentArmorType { get => currentArmorType; }
    public float CurrentArmorWeight { get => currentArmorWeight; }
    public float CurrentArmorDef { get => currentArmorDef; }
    public Armor CurrentTorsoArmorPrefab { get => currentTorsoArmorPrefab; }
    public Armor CurrentHelmetPrefab { get => currentHelmetPrefab; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDagger()
    {
        currentWeapon = dagger;
        SetWeaponValues();
        uiManager.SetDaggerImage();
    }

    public void SetLongSword()
    {
        currentWeapon = longSword;
        SetWeaponValues();
        uiManager.SetLongSwordImage();
    }
    public void SetShortSword()
    {
        currentWeapon = shortSword;
        SetWeaponValues();
        uiManager.SetShortSwordImage();
    }

    public void SetHammer()
    {
        currentWeapon = hammer;
        SetWeaponValues();
        uiManager.SetHammerImage();
    }

    public void SetLance()
    {
        currentWeapon = lance;
        SetWeaponValues();
        uiManager.SetLanceImage();
    }

    public void SetClothArmor()
    {
        currentArmor = clothArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetClothArmorImage();
        SetArmorValues();
    }

    public void SetLeatherArmor()
    {
        currentArmor = leatherArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetLeatherArmorImage();
        SetArmorValues();
    }

    public void SetIronArmor()
    {
        currentArmor = ironArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetIronArmorImage();
        SetArmorValues();
    }

    public void SetPlateArmor()
    {
        currentArmor = plateArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetPlateArmorImage();
        SetArmorValues();
    }

    private void SetWeaponValues()
    {
        currentWeaponType = currentWeapon.GetWeaponType();
        currentWeaponWeight = currentWeapon.GetWeaponWeight();
        currentWeaponMinDmg = currentWeapon.GetWeaponMinDmg();
        currentWeaponMaxDmg = currentWeapon.GetWeaponMaxDmg();
        currentWeaponPrefab = currentWeapon.GetWeaponPrefab();
    }

    private void SetArmorValues()
    {
        currentArmorName = currentArmor.GetArmorName();
        currentArmorType = currentArmor.GetArmorType();
        currentArmorWeight = currentArmor.GetArmorWeight();
        currentArmorDef = currentArmor.GetArmorDef();
        currentHelmetPrefab = currentArmor.GetHelmetPrefab();
        currentTorsoArmorPrefab = currentArmor.GetTorsoArmorPrefab();
    }
}
