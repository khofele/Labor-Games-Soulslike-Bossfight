using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("FlyBreatheFireAttackMagic")]
public class FlyBreatheFireMagic : GOAction
{
    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
    }

    public override TaskStatus OnUpdate()
    {
        bossController.Animator.SetTrigger(""); // TODO Animations Task
        attackManager.CurrentAttack = attackManager.AttackFlyBreatheFireMagic;
        Debug.Log("Fly Breathe Fire Attack (Magic)");

        // if Timer running
        // breathe fire + follow player

        // if Timer over
        return TaskStatus.COMPLETED;
    }
}
