using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideFireHeadAttack : GOAction
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
        attackManager.CurrentAttack = attackManager.AttackWideFireHead;
        Debug.Log("Wide Fire Head Attack");
        return TaskStatus.COMPLETED;
    }
}
