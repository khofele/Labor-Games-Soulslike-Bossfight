using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Death")]
public class Death : GOAction
{
    [InParam("GameManager")]
    [SerializeField] private GameManager gameManager = null;

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
        if (bossController.IsFlying == true && bossController.IsDead == false)
        {
            ResetFlyingAnimations();
            bossController.Animator.SetTrigger("FlyDeath");
            bossController.IsDead = true;
        }
        else if(bossController.IsDead == false)
        {
            ResetFloorAnimations();
            bossController.Animator.SetTrigger("Death");
            bossController.IsDead = true;
        }
        gameManager.GameRunning = false;
        Debug.Log("Boss died!");
        return TaskStatus.COMPLETED;
    }

    private void ResetFloorAnimations()
    {
        bossController.Animator.ResetTrigger("Attack 1");
        bossController.Animator.ResetTrigger("StunnedStanding");
        bossController.Animator.ResetTrigger("Fire Head 1");
        bossController.Animator.ResetTrigger("Walk");
        bossController.Animator.ResetTrigger("Hit 1");
        bossController.Animator.ResetTrigger("Hit 2");
        bossController.Animator.ResetTrigger("AttackFront");
        bossController.Animator.ResetTrigger("Attack 2");
        bossController.Animator.ResetTrigger("Idle");
    }

    private void ResetFlyingAnimations()
    {
        bossController.Animator.ResetTrigger("BreatheMagicFire");
        bossController.Animator.ResetTrigger("BreathePoisonFire");
        bossController.Animator.ResetTrigger("BreatheBasicFire");
        bossController.Animator.ResetTrigger("StunnedFlying");
        bossController.Animator.ResetTrigger("AttackFly");
        bossController.Animator.ResetTrigger("Hit 3");
    }
}
