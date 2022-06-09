using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private AttributeManager attributeManager = null;
    [SerializeField] private StartRunMenuUIManager uiManager = null;
    [SerializeField] private MenuPlayerUIManager menuPlayerUIManager = null;

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
    private WeaponTypeEnum currentWeaponType;
    private WeaponTypeHandedEnum currentWeaponTypeHanded;
    private float currentWeaponWeight = 0f;
    private float currentWeaponMinDmg = 0f;
    private float currentWeaponMaxDmg = 0f;
    private Weapon currentWeaponPrefab = null;

    private Armor currentArmor = null;
    private string currentArmorName = "";
    private ArmorTypeEnum currentArmorType;
    private float currentArmorWeight = 0f;
    private float currentArmorDef = 0f;
    private Armor currentTorsoArmorPrefab = null;
    private Armor currentHelmetPrefab = null;

    private int potionCount = 5;

    public int PotionCount { get => potionCount; }

    public Weapon CurrentWeapon { get => currentWeapon; }
    public WeaponTypeEnum CurrentWeaponType { get => currentWeaponType; }
    public WeaponTypeHandedEnum CurrentWeaponTypeHanded { get => currentWeaponTypeHanded; }
    public float CurrentWeaponWeight { get => currentWeaponWeight; }
    public float CurrentWeaponMinDmg { get => currentWeaponMinDmg; }
    public float CurrentWeaponMaxDmg { get => currentWeaponMaxDmg; }
    public Weapon CurrentWeaponPrefab { get => currentWeaponPrefab; }

    public Armor CurrentArmor { get => currentArmor; }
    public string CurrentArmorName { get => currentArmorName; }
    public ArmorTypeEnum CurrentArmorType { get => currentArmorType; }
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

    private void Start()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Start Run")
        {
            GameObject startRunUIGameObject = GameObject.Find("UI");
            uiManager = startRunUIGameObject.GetComponent<StartRunMenuUIManager>();
            GameObject playerUIGameObject = GameObject.Find("PlayerUI");
            menuPlayerUIManager = playerUIGameObject.GetComponent<MenuPlayerUIManager>();
        }
    }

    public void SetDagger()
    {
        currentWeapon = dagger;
        SetWeaponValues();
        uiManager.SetDaggerImage();
        menuPlayerUIManager.AttachWeapon();
    }

    public void SetLongSword()
    {
        currentWeapon = longSword;
        SetWeaponValues();
        uiManager.SetLongSwordImage();
        menuPlayerUIManager.AttachWeapon();
    }
    public void SetShortSword()
    {
        currentWeapon = shortSword;
        SetWeaponValues();
        uiManager.SetShortSwordImage();
        menuPlayerUIManager.AttachWeapon();
    }

    public void SetHammer()
    {
        currentWeapon = hammer;
        SetWeaponValues();
        uiManager.SetHammerImage();
        menuPlayerUIManager.AttachWeapon();
    }

    public void SetLance()
    {
        currentWeapon = lance;
        SetWeaponValues();
        uiManager.SetLanceImage();
        menuPlayerUIManager.AttachWeapon();
    }

    public void SetClothArmor()
    {
        currentArmor = clothArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetClothArmorImage();
        SetArmorValues();
        menuPlayerUIManager.AttachTorsoArmor();
        menuPlayerUIManager.AttachBasicHelmet();
    }

    public void SetLeatherArmor()
    {
        currentArmor = leatherArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetLeatherArmorImage();
        SetArmorValues();
        menuPlayerUIManager.AttachTorsoArmor();
        menuPlayerUIManager.AttachSpecialHelmet();
    }

    public void SetIronArmor()
    {
        currentArmor = ironArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetIronArmorImage();
        SetArmorValues();
        menuPlayerUIManager.AttachTorsoArmor();
        menuPlayerUIManager.AttachBasicHelmet();
    }

    public void SetPlateArmor()
    {
        currentArmor = plateArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetPlateArmorImage();
        SetArmorValues();
        menuPlayerUIManager.AttachTorsoArmor();
        menuPlayerUIManager.AttachSpecialHelmet();
    }

    private void SetWeaponValues()
    {
        currentWeaponType = currentWeapon.GetWeaponType();
        currentWeaponTypeHanded = currentWeapon.GetWeaponTypeHanded();
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

    public void ResetWeaponAndArmor()
    {
        currentArmor = null;
        currentWeapon = null;
        currentWeaponWeight = 0f;
        currentWeaponMinDmg = 0f;
        currentWeaponMaxDmg = 0f;
        currentWeaponPrefab = null;

        currentArmorName = "";
        currentArmorWeight = 0f;
        currentArmorDef = 0f;
        currentTorsoArmorPrefab = null;
        currentHelmetPrefab = null;
    }
}
