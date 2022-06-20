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

    //needed stamina needed for skills with current weapon
    private float neededStaminaAttack01 = 0f;
    private float neededStaminaAttack02 = 0f;
    private float neededStaminaAttack03 = 0f;
    private float neededStaminaHeavyAttack = 0f;
    private float neededStaminaRoll = 0f;

    private int potionCount = 3;

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

    //stamina value getter
    public float NeededStaminaAttack01 { get => neededStaminaAttack01; }
    public float NeededStaminaAttack02 { get => neededStaminaAttack02; }
    public float NeededStaminaAttack03 { get => neededStaminaAttack03; }
    public float NeededStaminaHeavyAttack { get => neededStaminaHeavyAttack; }
    public float NeededStaminaRoll { get => neededStaminaRoll; }

    //item descriptions
    public string ShortSwordDescription { get => "~Short Sword \n@A sword that was once found in a dragon's lair. It seems sharp and shiny.";  }
    public string LongSwordDescription { get => "~Longsword \n@A big sword that was once wielded by a famous hero."; }
    public string DaggerDescription { get => "~Daggers \n@One for every hand. They seem perfect together. \nSharp and fast."; }
    public string LanceDescription { get => "~Lance \n@Legends say this lance once belonged to Poseidon, god of the ocean. Nobody knows where it comes from and how it came into your possession."; }
    public string HammerDescription { get => "~Hammer \n@A heavy warhammer. It seems very old and powerful."; }
    public string ClothArmorDescription { get => "~Elven Armor \n@The armor seems light but still protecting."; }
    public string LeatherArmorDescription { get => "~Ogre Armor \n@This armor once belonged to Tesirok, the leader of the ogres from the northern fields. It seems to be made out of human skin and parts from animals."; }
    public string IronArmorDescription { get => "~Ork Armor \n@This armor once belonged to the famous knight of the orks, Grimfang the Mighty. \nIt looks very heavy."; }
    public string PlateArmorDescription { get => "~Plate Armor \n@A heavy looking armor out of metal plates."; }


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
        SetWeaponStaminaValues();
        uiManager.SetDaggerImage();
        menuPlayerUIManager.AttachWeapon();
    }

    public void SetLongSword()
    {
        currentWeapon = longSword;
        SetWeaponValues();
        SetWeaponStaminaValues();
        uiManager.SetLongSwordImage();
        menuPlayerUIManager.AttachWeapon();
    }
    public void SetShortSword()
    {
        currentWeapon = shortSword;
        SetWeaponValues();
        SetWeaponStaminaValues();
        uiManager.SetShortSwordImage();
        menuPlayerUIManager.AttachWeapon();
    }

    public void SetHammer()
    {
        currentWeapon = hammer;
        SetWeaponValues();
        SetWeaponStaminaValues();
        uiManager.SetHammerImage();
        menuPlayerUIManager.AttachWeapon();
    }

    public void SetLance()
    {
        currentWeapon = lance;
        SetWeaponValues();
        SetWeaponStaminaValues();
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

    //method to set the needed stamina for the chosen weapon
    private void SetWeaponStaminaValues()
    {
        neededStaminaAttack01 = currentWeapon.GetNeededStaminaAttack01();
        neededStaminaAttack02 = currentWeapon.GetNeededStaminaAttack02();
        neededStaminaAttack03 = currentWeapon.GetNeededStaminaAttack03();
        neededStaminaHeavyAttack = currentWeapon.GetNeededStaminaHeavyAttack();
        neededStaminaRoll = currentWeapon.GetNeededStaminaRoll();
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

        neededStaminaAttack01 = 0f;
        neededStaminaAttack02 = 0f;
        neededStaminaAttack03 = 0f;
        neededStaminaHeavyAttack = 0f;
        neededStaminaRoll = 0f;
    }
}
