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

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        bossController.Animator.SetTrigger("Breathe Fire");
        attackManager.CurrentAttack = attackManager.AttackFireHead;
        Debug.Log("Attack Fire Head");
        return TaskStatus.COMPLETED;
    }
}
