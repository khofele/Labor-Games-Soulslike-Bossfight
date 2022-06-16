using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class DeathState : BaseState
    {
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log("Death");
            animator.SetBool("diedBefore", true);

            //sound
            GetAudioPlayer(animator).PlayDeath();

            //stop stamina reg
            GetCharController(animator).SetRegStamina(false);
        }
    }

}