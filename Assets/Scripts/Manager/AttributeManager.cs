using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    [SerializeField] private SkillpointManager skillpointManager = null;
    [SerializeField] private ItemManager itemManager = null;
    private static AttributeManager instance = null;
    private float health = 1000f;
    private float stamina = 0f;
    private float staminaReg = 0.08f;
    private float carryingCapacity = 50f;
    private float resistance = 15f;
    private float defense = 50f;
    private float attackPower = 50f;
    private float multiplicator = 100f;

    public float Health { get => health; }
    public float Stamina { get => stamina; }
    public float StaminaReg { get => staminaReg; }
    public float CarryingCapacity { get => carryingCapacity; }
    public float Resistance { get => resistance; }
    public float Defense { get => defense; }
    public float AttackPower { get => attackPower; }

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

    public void CalcHealth()
    {
        health = health + skillpointManager.Vitality * multiplicator;
    }

    public void CalcStamina()
    {
        stamina = stamina + skillpointManager.Endurance * multiplicator;
    }

    public void CalcStaminaReg()
    {
        staminaReg = staminaReg + skillpointManager.Endurance * 4 / multiplicator;
    }

    public void CalcAttackPower()
    {
        attackPower = attackPower + skillpointManager.Strength;
    }

    public void CalcCarryingCapacity()
    {
        carryingCapacity = carryingCapacity + skillpointManager.PhysicalStrength * multiplicator;
    }

    public void CalcResistance()
    {
        resistance = itemManager.CurrentArmor.GetArmorDef() * multiplicator;
    }

    public void CalcDefense()
    {
        defense = itemManager.CurrentArmor.GetArmorDef() * multiplicator;
    }
}
