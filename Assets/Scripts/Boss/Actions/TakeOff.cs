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
        //for (int i = 0; i < 500; i++)
        //{
        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z);
        //}
        bossController.IsFlying = true;
        bossController.Animator.SetTrigger("TakeOff");
        bossController.IsFlyingTimer.StartTimer();
        return TaskStatus.COMPLETED;
    }
}
