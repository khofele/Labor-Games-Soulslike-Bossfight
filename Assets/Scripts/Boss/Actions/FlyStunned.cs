using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("FlyStunned")]
public class FlyStunned : GOAction
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
        bossController.Animator.SetTrigger("StunnedFlying");
        Debug.Log("boss fly stunned");
        while (bossController.IsStunnedTimer.TimerOver == false)
        {
            continue;
        }
        return TaskStatus.COMPLETED;
    }
}