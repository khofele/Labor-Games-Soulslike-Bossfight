using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Stunned")]
public class Stunned : GOAction
{
    [InParam("controller")]
    [SerializeField] private BossController bossController = null;

    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    public override TaskStatus OnUpdate()
    {
        attackManager.Animator.SetTrigger("StunnedStanding");
        // TODO: Stun
        Debug.Log("boss stunned");
        return TaskStatus.COMPLETED;
    }
}
