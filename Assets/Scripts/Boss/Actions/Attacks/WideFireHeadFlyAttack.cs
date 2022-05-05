using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("WideFireHeadFlyAttack")]
public class WideFireHeadFlyAttack : GOAction
{
    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        bossController.Animator.SetTrigger(""); // TODO Animations Task
        attackManager.CurrentAttack = attackManager.AttackFlyWideFireHead;
        Debug.Log("Wide Fire Head Attack");
        return TaskStatus.COMPLETED;
    }
}