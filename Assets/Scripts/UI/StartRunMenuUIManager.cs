using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartRunMenuUIManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private SkillpointManager skillpointManager = null;
    [SerializeField] private AttributeManager attributeManager = null;
    [SerializeField] private ItemManager itemManager = null;

    [Header("Buttons")]
    [SerializeField] private Button btnBackToMainMenu = null;
    [SerializeField] private Button btnStartRun = null;
    [SerializeField] private Button btnAddVitality = null;
    [SerializeField] private Button btnRemoveVitality = null;
    [SerializeField] private Button btnAddEndurance = null;
    [SerializeField] private Button btnRemoveEndurance = null;
    [SerializeField] private Button btnAddStrength = null;
    [SerializeField] private Button btnRemoveStrength = null;
    [SerializeField] private Button btnAddPhysicalStrength = null;
    [SerializeField] private Button btnRemovePhysicalStrength = null;

    [Header("Stats")]
    [SerializeField] private TextMeshProUGUI skillPoints = null;
    [SerializeField] private TextMeshProUGUI vitality = null;
    [SerializeField] private TextMeshProUGUI endurance = null;
    [SerializeField] private TextMeshProUGUI strength = null;
    [SerializeField] private TextMeshProUGUI physicalStrength = null;

    [Header("Attributes")]
    [SerializeField] private TextMeshProUGUI health = null;
    [SerializeField] private TextMeshProUGUI stamina = null;
    [SerializeField] private TextMeshProUGUI staminaReg = null;
    [SerializeField] private TextMeshProUGUI carryingCapacity = null;
    [SerializeField] private TextMeshProUGUI resistance = null;
    [SerializeField] private TextMeshProUGUI defense = null;
    [SerializeField] private TextMeshProUGUI attackPower = null;

    [Header("Equipment")]
    [SerializeField] private TextMeshProUGUI carryingCapacityEquipment = null;
    [SerializeField] private Button btnShortSword = null;
    [SerializeField] private Button btnLongSword = null;
    [SerializeField] private Button btnLance = null;
    [SerializeField] private Button btnHammer = null;
    [SerializeField] private Button btnDagger = null;
    [SerializeField] private Button btnClothArmor = null;
    [SerializeField] private Button btnLeatherArmor = null;
    [SerializeField] private Button btnIronArmor = null;
    [SerializeField] private Button btnPlateArmor = null;

    private float weight = 0f;

    private void Start()
    {
        btnBackToMainMenu.onClick.AddListener(BackToMainMenu);
        btnStartRun.onClick.AddListener(StartGame);

        btnAddVitality.onClick.AddListener(skillpointManager.AddVitality);
        btnRemoveVitality.onClick.AddListener(skillpointManager.RemoveVitality);
        btnAddEndurance.onClick.AddListener(skillpointManager.AddEndurance);
        btnRemoveEndurance.onClick.AddListener(skillpointManager.RemoveEndurance);
        btnAddStrength.onClick.AddListener(skillpointManager.AddStrength);
        btnRemoveStrength.onClick.AddListener(skillpointManager.RemoveStrength);
        btnAddPhysicalStrength.onClick.AddListener(skillpointManager.AddPhysicalStrength);
        btnRemovePhysicalStrength.onClick.AddListener(skillpointManager.RemovePhysicalStrength);

        //btnDagger.onClick.AddListener(itemManager.SetDaggerPrefab);
        btnClothArmor.onClick.AddListener(itemManager.SetClothArmor); // TODO Listener setzen!
    }

    private void Update()
    {
        // Stats
        skillPoints.text = skillpointManager.Skillpoints.ToString() + "/10"; // TODO
        vitality.text = skillpointManager.Vitality.ToString();
        endurance.text = skillpointManager.Endurance.ToString();
        strength.text = skillpointManager.Strength.ToString();
        physicalStrength.text = skillpointManager.PhysicalStrength.ToString();

        // Attributes
        health.text = attributeManager.Health.ToString();
        stamina.text = attributeManager.Stamina.ToString();
        staminaReg.text = attributeManager.StaminaReg.ToString();
        carryingCapacity.text = attributeManager.CarryingCapacity.ToString();
        resistance.text = attributeManager.Resistance.ToString();
        defense.text = attributeManager.Defense.ToString();
        attackPower.text = attributeManager.AttackPower.ToString();

        // Equipment
        weight = itemManager.CurrentArmor.GetArmorWeight(); // + itemManager.CurrentWeapon.GetWeaponWeight();
        //carryingCapacity.text = weight.ToString() + "/" + carryingCapacity.ToString();
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
