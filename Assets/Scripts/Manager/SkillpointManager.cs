using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillpointManager : MonoBehaviour
{
    [SerializeField] private AttributeManager attributeManager = null;
    private static SkillpointManager instance = null;
    private int skillpoints = 0;
    private int maxSkillpoints = 10; 
    private int vitality = 0;
    private int endurance = 0;
    private int strength = 0;
    private int physicalStrength = 0;

    public int Skillpoints { get => skillpoints; }
    public int MaxSkillpoints { get => maxSkillpoints; }
    public int Vitality { get => vitality; }
    public int Endurance { get => endurance; }
    public int Strength { get => strength; }
    public int PhysicalStrength { get => physicalStrength; }

    // stat descriptions
    public string VitalityDescription { get => "~Vitality \n@The vitality of the character determines how many hits he can take."; }
    public string EnduranceDescription { get => "~Endurance \n@The endurance of the character determines his physical fitness."; }
    public string StrengthDescription { get => "~Strength \n@The strength of the character determines the force of his weapon swings."; }
    public string PhysicalStrengthDescription { get => "~Physical Strength \n@The pyhsical strength of the character determines what he is strong enough to carry."; }


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

        ResetAllSkillpoints();
    }

    private void Start()
    {
        skillpoints = maxSkillpoints;
    }

    //--------------------------ADD AND REMOVE SKILLPOINTS-----------------------

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
            attributeManager.CalcRemovedHealth();
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
            attributeManager.CalcRemovedStamina();
            attributeManager.CalcRemovedStaminaReg();
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
            attributeManager.CalcRemovedAttackPower();
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
            attributeManager.CalcRemovedCarryingCapacity();
        }
    }

    // reset skillponts/stats
    public void ResetAllSkillpoints()
    {
        skillpoints = maxSkillpoints;
        vitality = 0;
        endurance = 0;
        strength = 0;
        physicalStrength = 0;
    }
}
