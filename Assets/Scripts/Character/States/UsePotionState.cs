using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class UsePotionState : BaseState
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("UsePotion");

            //sound
            GetAudioPlayer(animator).PlayHeal();

            //call CharacterMovement method to use potion
            GetCharacterMovement(animator).UsePotion();
        }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("UsePotion", false);

            //destroy potion object
            GetCharController(animator).DestroyPotion();
        }
    }

}