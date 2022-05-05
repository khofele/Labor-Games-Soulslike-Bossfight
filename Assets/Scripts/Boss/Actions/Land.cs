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
        bossController.Animator.SetTrigger("Land");
        for(int i = 0; i < 500; i++)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-0.1f, gameObject.transform.position.z);
        }
        bossController.FlyTimer.StartTimer();
        bossController.IsFlying = false;
        return TaskStatus.COMPLETED;
    }
}
