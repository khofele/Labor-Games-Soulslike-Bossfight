using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enum for all skills (except running) that need stamina and their needed stamina values
public enum NeededStaminaSkills: int
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
    //stamina reg value (how much stamina is regenerated at once)
    private float staminaReg = 0f; 
    public float StaminaReg { set => staminaReg = value; } //set by CharController
    //max stamina of the player
    private float stamina = 0f;
    public float Stamina { set => stamina = value; } //set by CharController
    //current stamina 
    private float currentStamina = 0f;
    public float CurrentStamina { get => currentStamina; set => currentStamina = value; } //set by CharController and used for UI
    //whether stamina regeneration is currently true or false (false if skill used)
    private bool regStamina = true;
    public bool RegStamina { get => regStamina; set => regStamina = value; }


    //method to check whether there is enough stamina available for a skill or not
    public bool CheckEnoughStamina(NeededStaminaSkills currentSkill)
    {
        float neededStamina = (float)currentSkill; //set float value of current skill enum as neededStamina value

        if (currentStamina >= neededStamina)
        {
            return true;
        }
        else return false;
    }


    //method to call when skills need stamina
    public void UseStamina(float usedStamina)
    {
        if (currentStamina - usedStamina >= 0f)
        {
            currentStamina = currentStamina - usedStamina;
        }
    }


    //method called in CharController to regenerate the current stamina with time (if not using a skill at the moment)
    public void RegenerateStamina()
    {
        if (regStamina && currentStamina + staminaReg <= stamina) //reg not more stamina than the max value
        {
           currentStamina += staminaReg;
        }
    }
}
