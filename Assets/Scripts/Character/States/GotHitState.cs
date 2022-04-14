using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class GotHitState : BaseState
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("GotHit");

            //player has currently been hit - animation shall not play twice at a time
            animator.SetBool("alreadyHit", true);

            //set all bool parameters of aborted actions to false
            //damage combo is aborted
            animator.SetBool("Attack01R", false);
            animator.SetBool("Attack02R", false);

            //TODO: ersetzen durch finalen Code (Ticket genaue Hit Detection + erhaltener Dmg Berechnung)
            float damage = 0f;
            GetCharController(animator).GotHit(damage);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
            
        //}

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("GotHit", false);
            animator.SetBool("alreadyHit", false);
        }
    }

}