using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
    [SerializeField] private SkillpointManager skillpointManager = null;
    [SerializeField] private ItemManager itemManager = null;
    private static AttributeManager instance = null;
    private float health = 0f;
    private float stamina = 0f;
    private float staminaReg = 0f;
    private float carryingCapacity = 0f;
    private float resistance = 0f;
    private float defense = 0f;
    private float attackPower = 0f;
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

        ResetHealth();
        ResetStamina();
        ResetStaminaReg();
        ResetCarryingCapacity();
        ResetResistance();
        ResetDefense();
        ResetAttackPower();
    }

    public void CalcHealth()
    {
        health = health + skillpointManager.Vitality * multiplicator;
    }

    public void CalcRemovedHealth()
    {
        health = health - (skillpointManager.Vitality+1) * multiplicator;
    }

    public void CalcStamina()
    {
        stamina = stamina + skillpointManager.Endurance * multiplicator;
    }

    public void CalcRemovedStamina()
    {
        stamina = stamina - (skillpointManager.Endurance+1) * multiplicator;
    }

    public void CalcStaminaReg()
    {
        staminaReg = staminaReg + skillpointManager.Endurance * 4 / multiplicator;
        staminaReg = Mathf.Round(staminaReg * 100) / 100;
    }

    public void CalcRemovedStaminaReg()
    {
        staminaReg = staminaReg - (skillpointManager.Endurance+1) * 4 / multiplicator;
        staminaReg = Mathf.Round(staminaReg * 100) / 100;
    }

    public void CalcAttackPower()
    {
        attackPower = attackPower + skillpointManager.Strength;
    }

    public void CalcRemovedAttackPower()
    {
        attackPower = attackPower - (skillpointManager.Strength+1);
    }

    public void CalcCarryingCapacity()
    {
        carryingCapacity = carryingCapacity + skillpointManager.PhysicalStrength;
    }    

    public void CalcRemovedCarryingCapacity()
    {
        carryingCapacity = carryingCapacity - (skillpointManager.PhysicalStrength+1);
    }

    public void CalcResistance()
    {
        resistance = itemManager.CurrentArmor.GetArmorDef() * multiplicator;
    }

    public void CalcDefense()
    {
        defense = itemManager.CurrentArmor.GetArmorDef() * multiplicator;
    }

    public void ResetAllAttributes()
    {
        ResetHealth();
        ResetStamina();
        ResetStaminaReg();
        ResetCarryingCapacity();
        ResetResistance();
        ResetDefense();
        ResetAttackPower();
    }

    private void ResetHealth()
    {
        health = 1000f;
    }

    private void ResetStamina()
    {
        stamina = 100f;
    }

    private void ResetStaminaReg()
    {
        staminaReg = 0.08f;
    }

    private void ResetCarryingCapacity()
    {
        carryingCapacity = 27f;
    }

    private void ResetResistance()
    {
        resistance = 15f;
    }

    private void ResetDefense()
    {
        defense = 50f;
    }

    private void ResetAttackPower()
    {
        attackPower = 50f;
    }
}
