using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class NoPotionsState : BaseState
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //call CharacterMovement method to use potion
            GetCharacterMovement(animator).UsePotion();
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("UsePotion", false);

            //destroy potion object
            GetCharController(animator).DestroyPotion();
        }
    }
}