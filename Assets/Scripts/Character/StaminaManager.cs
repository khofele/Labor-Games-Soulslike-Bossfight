using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to manage the stamina of the character, used by the CharController and CharMovement script
public class StaminaManager : MonoBehaviour
{
    //current skill stamina needed - set after weapon chosen
    private float neededStaminaAttack01 = 0f;
    private float neededStaminaAttack02 = 0f;
    private float neededStaminaAttack03 = 0f;
    private float neededStaminaHeavyAttack = 0f;
    private float neededStaminaRoll = 0f;
    //values set in CharController via ItemManager, Getter for CharMovement -> CheckEnoughStamina and states
    public float NeededStaminaAttack01 { get => neededStaminaAttack01; set => neededStaminaAttack01 = value; }
    public float NeededStaminaAttack02 { get => neededStaminaAttack02; set => neededStaminaAttack02 = value; }
    public float NeededStaminaAttack03 { get => neededStaminaAttack03; set => neededStaminaAttack03 = value; }
    public float NeededStaminaHeavyAttack { get => neededStaminaHeavyAttack; set => neededStaminaHeavyAttack = value; }
    public float NeededStaminaRoll { get => neededStaminaRoll; set => neededStaminaRoll = value; }


    private float staminaReg = 0f; //stamina reg value (how much stamina is regenerated at once)
    private float stamina = 0f; //max stamina of the player
    private float currentStamina = 0f; //current stamina
    private bool regStamina = true; //whether stamina regeneration is currently true or false (false if skill used)

    public float StaminaReg { set => staminaReg = value; } //set by CharController
    public float Stamina { set => stamina = value; } //set by CharController
    public float CurrentStamina { get => currentStamina; set => currentStamina = value; } //set by CharController and used for UI
    public bool RegStamina { get => regStamina; set => regStamina = value; }


    //method to check whether there is enough stamina available for a skill or not
    public bool CheckEnoughStamina(float neededStamina)
    {
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
