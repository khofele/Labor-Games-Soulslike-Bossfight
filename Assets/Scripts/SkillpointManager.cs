using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillpointManager : MonoBehaviour
{
    [SerializeField] private AttributeManager attributeManager = null;
    private static SkillpointManager instance = null;
    private int skillpoints = 10; // TODO Balancing
    private int vitality = 0;
    private int endurance = 0;
    private int strength = 0;
    private int physicalStrength = 0;

    public int Skillpoints { get => skillpoints; }
    public int Vitality { get => vitality; }
    public int Endurance { get => endurance; }
    public int Strength { get => strength; }
    public int PhysicalStrength { get => physicalStrength; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddVitality()
    {
        if(skillpoints > 0)
        {
            vitality++;
            skillpoints--;
            attributeManager.CalcHealth();
        }
    }

    public void RemoveVitality()
    {
        if(vitality > 0)
        {
            vitality--;
            skillpoints++;
            attributeManager.CalcHealth();
        }
    }

    public void AddEndurance()
    {
        if(skillpoints > 0)
        {
            endurance++;
            skillpoints--;
            attributeManager.CalcStamina();
            attributeManager.CalcStaminaReg();
        }
    }

    public void RemoveEndurance()
    {
        if(endurance > 0)
        {
            endurance--;
            skillpoints++;
            attributeManager.CalcStamina();
            attributeManager.CalcStaminaReg();
        }
    }

    public void AddStrength()
    {
        if(skillpoints > 0)
        {
            strength++;
            skillpoints--;
            attributeManager.CalcAttackPower();
        }
    }

    public void RemoveStrength()
    {
        if(strength > 0)
        {
            strength--;
            skillpoints++;
            attributeManager.CalcAttackPower();
        }
    }
    public void AddPhysicalStrength()
    {
        if(skillpoints > 0)
        {
            physicalStrength++;
            skillpoints--;
            attributeManager.CalcCarryingCapacity();
        }
    }

    public void RemovePhysicalStrength()
    {
        if (physicalStrength > 0)
        {
            physicalStrength--;
            skillpoints++;
            attributeManager.CalcCarryingCapacity();
        }
    }
}
