using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("TakeOff")]
public class TakeOff : GOAction
{
    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        bossController.IsFlying = true;
        bossController.Animator.SetTrigger("TakeOff");
        bossController.FlyTimer.StartTimer();
        return TaskStatus.COMPLETED;
    }
}
