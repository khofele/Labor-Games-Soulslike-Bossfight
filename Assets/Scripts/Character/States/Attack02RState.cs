using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class Attack02RState : BaseState
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Attack02");

            //use neededStamina for action
            neededStamina = 25f;
            GetCharacterMovement(animator).UseStamina(neededStamina);
            GetCharacterMovement(animator).SetRegStamina(false); //no stamina reg during skill
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}
    }

}