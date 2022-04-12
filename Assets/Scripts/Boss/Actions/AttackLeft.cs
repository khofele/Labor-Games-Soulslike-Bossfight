using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("AttackLeft")]
public class AttackLeft : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    public override TaskStatus OnUpdate()
    {
        attackManager.Animator.SetTrigger(attackManager.AttackLeft.Animation.name);
        attackManager.CurrentAttack = attackManager.AttackLeft;
        Debug.Log("Attack Left");
        return TaskStatus.COMPLETED;
    }
}
