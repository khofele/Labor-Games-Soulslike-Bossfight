using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class Attack03RState : BaseState
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //set isAttacking in CharController to true
            GetCharController(animator).IsAttacking = true;
            //enable weapon collider
            GetCharController(animator).EnableCollider();

            //use neededStamina for action
            neededStamina = GetStaminaManager(animator).NeededStaminaAttack03;
            GetCharController(animator).UseStamina(neededStamina);
            GetCharController(animator).SetRegStamina(false); //no stamina reg during skill
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //character finished combo attack
            Debug.Log("03 false");
            animator.SetBool("Attack03R", false);
            GetCharController(animator).SetRegStamina(true); //regenerate stamina again
            GetCharController(animator).IsAttacking = false; //set isAttacking in CharController to false
            GetCharController(animator).DisableCollider(); //disable weapon collider
        }
    }

}
