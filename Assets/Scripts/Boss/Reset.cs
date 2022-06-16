using stateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : StateMachineBehaviour
{
    [SerializeField] AttackManager attackManager = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack 1");
        animator.ResetTrigger("StunnedStanding");
        animator.ResetTrigger("Fire Head 1");
        animator.ResetTrigger("Walk");
        animator.ResetTrigger("Hit 1");
        animator.ResetTrigger("Hit 2");
        animator.ResetTrigger("TakeOff");
        animator.ResetTrigger("StunnedFlying");
        animator.ResetTrigger("AttackFly");
        animator.ResetTrigger("BreatheMagicFire");
        animator.ResetTrigger("BreathePoisonFire");
        animator.ResetTrigger("BreatheBasicFire");
        animator.ResetTrigger("Hit 3");
        animator.ResetTrigger("AttackFront");
        animator.ResetTrigger("Attack 2");
        animator.ResetTrigger("Land");
        animator.applyRootMotion = true;

        attackManager.CurrentAttack = attackManager.NullAttack;
    }
}
