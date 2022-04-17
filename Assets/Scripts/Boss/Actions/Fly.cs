using BBUnity.Actions;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : GOAction
{
    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        bossController.Animator.SetTrigger(""); // TODO Animations Task
        // TODO: Flugmechanik siehe Ticket
        return TaskStatus.COMPLETED;
    }
}
