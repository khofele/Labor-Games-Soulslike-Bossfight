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
    }

    public override TaskStatus OnUpdate()
    {
        if(bossController.IsFlying == true)
        {
            bossController.Animator.SetTrigger("FlyDeath");
        }
        else
        {
            bossController.Animator.SetTrigger("Death");
        }

        // TODO: End Game/back to menu --> GameManager
        Debug.Log("Boss died!");
        return TaskStatus.COMPLETED;
    }

}
