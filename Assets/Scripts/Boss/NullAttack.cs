using stateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullAttack : BaseState
{
    [SerializeField] AttackManager attackManager = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackManager.CurrentAttack = attackManager.NullAttack;
    }
}
