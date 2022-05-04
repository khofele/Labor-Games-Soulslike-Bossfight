using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Land")]
public class Land : GOAction
{
    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        // TODO: with Animations Task: Drache entsprechend weit runter bewegen damit Landing Animation passt
        //gameObject.transform.position = new Vector3();
        bossController.Animator.SetTrigger(""); // TODO Animations Task
        bossController.FlyTimer.StartTimer();
        bossController.IsFlying = false;
        return TaskStatus.COMPLETED;
    }
}
