using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Intro")]
public class Intro : GOAction
{
    private BossController bossController = null;
    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return TaskStatus.COMPLETED;
        }
        else
        {
            return TaskStatus.RUNNING;
        }
    }
}
