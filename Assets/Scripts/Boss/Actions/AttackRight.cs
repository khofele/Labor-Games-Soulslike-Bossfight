using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("AttackRight")]
public class AttackRight : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    public override TaskStatus OnUpdate()
    {
        attackManager.Animator.SetTrigger(attackManager.AttackRight.Animation.name);
        attackManager.CurrentAttack = attackManager.AttackRight;
        Debug.Log("Attack Right");
        return TaskStatus.COMPLETED;
    }
}
