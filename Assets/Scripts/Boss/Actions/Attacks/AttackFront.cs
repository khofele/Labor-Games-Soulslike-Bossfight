using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("AttackFront")]
public class AttackFront : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
        bossController.Animator.ResetTrigger("Walk");
        bossController.Animator.ResetTrigger("Idle");
    }


    public override TaskStatus OnUpdate()
    {
        bossController.Animator.SetTrigger("AttackFront");
        attackManager.CurrentAttack = attackManager.AttackFront;
        bossController.Player.IsCollided = false;
        Debug.Log("Attack Front");
        return TaskStatus.COMPLETED;
    }
}
