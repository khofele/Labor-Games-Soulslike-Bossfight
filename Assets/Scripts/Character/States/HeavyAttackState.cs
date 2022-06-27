using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class HeavyAttackState : BaseState
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //set isAttacking in CharController to true
            GetCharController(animator).IsAttacking = true;
            //enable weapon collider
            GetCharController(animator).EnableCollider();

            //use neededStamina for action
            neededStamina = GetStaminaManager(animator).NeededStaminaHeavyAttack;
            GetCharController(animator).UseStamina(neededStamina);
            GetCharController(animator).SetRegStamina(false); //no stamina reg during skill
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //player finished attack
            animator.SetBool("HeavyAttack", false);
            GetCharController(animator).SetRegStamina(true); //regenerate stamina again
            GetCharController(animator).IsAttacking = false; //set isAttacking in CharController to false
            GetCharController(animator).DisableCollider(); //disable weapon collider
        }
    }

}