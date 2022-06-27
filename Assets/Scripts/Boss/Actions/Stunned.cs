using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Stunned")]
public class Stunned : GOAction
{
    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
        bossController.Animator.ResetTrigger("Walk");
        bossController.Animator.ResetTrigger("Idle");
    }

    public override TaskStatus OnUpdate()
    {
        Debug.Log("boss stunned");
        if(bossController.IsFlying == true)
        {
            bossController.Animator.SetTrigger("StunnedFlying");
            if(bossController.IsStunnedTimer.TimerOver == true)
            {
                bossController.IsStunned = false;
                return TaskStatus.COMPLETED;
            }
            else
            {
                return TaskStatus.RUNNING;
            }

        }
        else
        {                
            bossController.Animator.SetTrigger("StunnedStanding");
            if (bossController.IsStunnedTimer.TimerOver == true)
            {
                bossController.IsStunned = false;
                return TaskStatus.COMPLETED;
            }
            else
            {
                return TaskStatus.RUNNING;
            }
        }
    }
}
