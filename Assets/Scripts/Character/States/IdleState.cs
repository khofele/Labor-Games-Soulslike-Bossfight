using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class IdleState : BaseState
    {
        

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Idle");

            //set every bool to false and stamina reg to true because the character is idle
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Attack01R", false);
            animator.SetBool("Attack02R", false);
            animator.SetBool("Attack03R", false);
            animator.SetBool("HeavyAttack", false);
            animator.SetBool("UsePotion", false);
            animator.SetBool("Roll", false);
            GetCharController(animator).SetRegStamina(true);

            //Debug.Log("01, 02, 03 false");
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
           
        }
    }

}