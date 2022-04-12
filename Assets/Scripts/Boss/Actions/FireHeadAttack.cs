using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("FireHeadAttack")]
public class FireHeadAttack : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    public override TaskStatus OnUpdate()
    {
        // play attack animation
        attackManager.CurrentAttack = attackManager.AttackFireHead;
        Debug.Log("Attack Fire Head");
        return TaskStatus.COMPLETED;
    }
}
