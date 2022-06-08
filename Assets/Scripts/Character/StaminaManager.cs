using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enum for all skills (except running) that need stamina and their needed stamina values
public enum NeededStaminaSkills
{
    ATTACK01R = 25,
    ATTACK02R = 25,
    ATTACK03R = 25,
    HEAVYATTACK = 40,
    ROLL = 60,
}

//class to manage the stamina of the character, used by the CharController and CharMovement script
public class StaminaManager : MonoBehaviour
{
    //current stamina of the player
    private float currentStamina;
    public float CurrentStamina { get => currentStamina; }
    //whether stamina regeneration is currently true or false (false if skill used)
    private bool regStamina;
    public bool RegStamina { get => regStamina; }


    //method to call when skills need stamina
    public void UseStamina(float usedStamina)
    {
        if (currentStamina - usedStamina >= 0f)
        {
            currentStamina = currentStamina - usedStamina;
        }
    }


    //setter for the bool regStamina - whether stamina shall be regenerated or not
    public void SetRegStamina(bool regStaminaValue)
    {
        regStamina = regStaminaValue;
    }
}
