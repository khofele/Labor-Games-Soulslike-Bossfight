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
        bossController.GetComponent<Animator>().applyRootMotion = false;
    }

    public override TaskStatus OnUpdate()
    {
        bossController.IsFlying = true;
        bossController.Animator.SetTrigger("TakeOff");
        bossController.IsFlyingTimer.StartTimer();
        if(bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle Takeoff"))
        {
            bossController.GetComponent<Animator>().applyRootMotion = true;
            return TaskStatus.COMPLETED;
        }
        else
        {
            return TaskStatus.RUNNING;
        }

    }
}
