using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class GotStunnedState : BaseState
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //currently stunned
            animator.SetBool("alreadyStunned", true);

            //sound
            GetAudioPlayer(animator).PlayHit();

            //set all bool parameters of aborted actions to false
            animator.SetBool("Attack01R", false);
            animator.SetBool("Attack02R", false);
            animator.SetBool("Attack03R", false);
            animator.SetBool("HeavyAttack", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("GotStunned", false);
            animator.SetBool("alreadyStunned", false);
        }
    }

}
