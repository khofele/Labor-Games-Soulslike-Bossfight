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
        bossController.Animator.ResetTrigger("Walk");
        bossController.Animator.ResetTrigger("Idle");
    }

    public override TaskStatus OnUpdate()
    {
        if(bossController.IsFlying == false)
        {
            bossController.Animator.ResetTrigger("Idle");
            bossController.Animator.SetTrigger("TakeOff");

            bossController.FlyTimer.TimerEnd();
            bossController.IsFlyingTimer.StartTimer();
            bossController.Animator.SetTrigger("FlyIdle");
            if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle Takeoff"))
            {
                bossController.IsFlying = true;
                Debug.Log("complete");
                return TaskStatus.COMPLETED;
            }
            else
            {
                return TaskStatus.RUNNING;
            }
        }
        else
        {
            return TaskStatus.ABORTED;
        }
    }
}
