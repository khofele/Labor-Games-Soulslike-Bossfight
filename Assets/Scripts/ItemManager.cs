using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("Armor")]
    [SerializeField] private ClothArmor clothArmor = null;
    [SerializeField] private IronArmor ironArmor = null;
    [SerializeField] private LeatherArmor leatherArmor = null;
    [SerializeField] private PlateArmor plateArmor = null;

    //[Header("Weapons")]
    //[SerializeField] private Shortsword shortSword = null;
    //[SerializeField] private Longsword longSword = null;
    //[SerializeField] private Dagger dagger = null;
    //[SerializeField] private Hammer hammer = null;
    //[SerializeField] private Lance lance = null;

    private static ItemManager instance = null;
    private Weapon currentWeapon = null;
    [SerializeField] private Armor currentArmor = null;

    public Weapon CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }
    public Armor CurrentArmor { get => currentArmor; set => currentArmor = value; }

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
        currentArmor = clothArmor;
        //currentWeapon = shortSword;
    }

    //public void SetDaggerPrefab()
    //{
    //    currentWeapon = dagger.GetWeaponPrefab();
    //}

    //public void SetLongSwordPrefab()
    //{
    //    currentWeapon = longSword.GetWeaponPrefab();
    //}
    //public void SetShortSwordPrefab()
    //{
    //    currentWeapon = shortSword.GetWeaponPrefab();
    //}

    //public void SetHammerPrefab()
    //{
    //    currentWeapon = hammer.GetWeaponPrefab();
    //}

    //public void SetLancePrefab()
    //{
    //    currentWeapon = lance.GetWeaponPrefab();
    //}

    public void SetClothArmor()
    {
        currentArmor = clothArmor;
    }

    public void SetLeatherArmor()
    {
        currentArmor = leatherArmor;
    }

    public void SetIronArmor()
    {
        currentArmor = ironArmor;
    }

    public void SetPlateArmor()
    {
        currentArmor = plateArmor;
    }
}
