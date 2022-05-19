using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("FlyAttack")]
public class FlyAttack : GOAction
{
    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }
    // TODO on hold
    public override TaskStatus OnUpdate()
    {
        bossController.Animator.SetTrigger("AttackFly");
        //attackManager.CurrentAttack = attackManager.AttackFly; 
        Debug.Log("Fly Attack");
        return TaskStatus.COMPLETED;
    }
}
