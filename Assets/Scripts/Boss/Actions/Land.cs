using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Action("Land")]
public class Land : GOAction
{
    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
        bossController.GetComponent<Animator>().applyRootMotion = true;
    }

    public override TaskStatus OnUpdate()
    {
        bossController.Animator.ResetTrigger("TakeOff");
        bossController.Animator.ResetTrigger("BreatheBasicFire");
        bossController.Animator.ResetTrigger("BreathePoisonFire");
        bossController.Animator.ResetTrigger("BreatheMagicFire");

        if(bossController.transform.position == new Vector3(0, 20, 0))
        {
            bossController.Animator.SetTrigger("Land");
            bossController.FlyTimer.StartTimer();
            bossController.IsFlying = false;
            if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle Landing"))
            {
                bossController.GetComponent<Animator>().applyRootMotion = true;
                return TaskStatus.COMPLETED;
            }
            else
            {
                return TaskStatus.RUNNING;
            }
        }
        return TaskStatus.RUNNING;
    }
}
