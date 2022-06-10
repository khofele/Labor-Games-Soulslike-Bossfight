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
            Debug.Log("Attack03");

            //set isAttacking in CharController to true
            GetCharController(animator).IsAttacking = true;

            //use neededStamina for action
            neededStamina = (float)NeededStaminaSkills.ATTACK03R;
            GetCharController(animator).UseStamina(neededStamina);
            GetCharController(animator).SetRegStamina(false); //no stamina reg during skill
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //character finished combo attack
            Debug.Log("03 false");
            animator.SetBool("Attack03R", false);
            GetCharController(animator).SetRegStamina(true); //regenerate stamina again
            GetCharController(animator).IsAttacking = false; //set isAttacking in CharController to false
        }
    }

}
