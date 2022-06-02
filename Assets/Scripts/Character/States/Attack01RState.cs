using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class Attack01RState : BaseState
    {

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Attack01");

            //set isAttacking in CharController to true
            GetCharController(animator).IsAttacking = true;

            animator.SetFloat("currentStamina", neededStamina);

            //use neededStamina for action
            neededStamina = 25f;
            GetCharController(animator).UseStamina(neededStamina);
            GetCharController(animator).SetRegStamina(false); //no stamina reg during skill
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (GetCharController(animator).GetCurrentWeapon().Contains("Lance"))
            {
                animator.SetBool("Attack01R", false);
                GetCharController(animator).SetRegStamina(true); //regenerate stamina again
            }
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //set isAttacking in CharController to false
            GetCharController(animator).IsAttacking = false;
        }
    }

}