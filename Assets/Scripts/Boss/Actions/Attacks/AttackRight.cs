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

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        if(bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            bossController.Animator.SetTrigger("Attack 1");
        }
        attackManager.CurrentAttack = attackManager.AttackRight;
        Debug.Log("Attack Right");
        return TaskStatus.COMPLETED;
    }
}
