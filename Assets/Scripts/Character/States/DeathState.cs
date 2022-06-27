using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace stateMachine
{
    public class DeathState : BaseState
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("diedBefore", true);

            //sound
            GetAudioPlayer(animator).PlayDeath();

            //stop stamina reg
            GetCharController(animator).SetRegStamina(false);
        }
    }

}