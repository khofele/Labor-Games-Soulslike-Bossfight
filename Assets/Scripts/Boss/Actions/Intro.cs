using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Intro")]
public class Intro : GOAction
{
    [InParam("uimanager")]
    [SerializeField] private UIManager uiManager = null;

    private BossController bossController = null;
    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
        uiManager.EnableBossName();
    }

    public override TaskStatus OnUpdate()
    {
        if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            uiManager.DisableBossName();
            uiManager.EnableHealthBarBoss();
            uiManager.EnableHealthBarChar();
            uiManager.EnablePotionField();
            uiManager.EnableStaminaBar();
            return TaskStatus.COMPLETED;
        }
        else
        {
            return TaskStatus.RUNNING;
        }
    }
}
