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
    private Armor currentArmor = null;
    private int potionCount = 5;

    public Weapon CurrentWeapon { get => currentWeapon; }
    public Armor CurrentArmor { get => currentArmor; }
    public int PotionCount { get => potionCount; }

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
        uiManager.SetDaggerImage();
    }

    public void SetLongSword()
    {
        currentWeapon = longSword;
        uiManager.SetLongSwordImage();
    }
    public void SetShortSword()
    {
        currentWeapon = shortSword;
        uiManager.SetShortSwordImage();
    }

    public void SetHammer()
    {
        currentWeapon = hammer;
        uiManager.SetHammerImage();
    }

    public void SetLance()
    {
        currentWeapon = lance;
        uiManager.SetLanceImage();
    }

    public void SetClothArmor()
    {
        currentArmor = clothArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetClothArmorImage();
    }

    public void SetLeatherArmor()
    {
        currentArmor = leatherArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetLeatherArmorImage();
    }

    public void SetIronArmor()
    {
        currentArmor = ironArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetIronArmorImage();
    }

    public void SetPlateArmor()
    {
        currentArmor = plateArmor;
        attributeManager.CalcResistance();
        attributeManager.CalcDefense();
        uiManager.SetPlateArmorImage();
    }
}
