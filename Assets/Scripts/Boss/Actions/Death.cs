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

    public override TaskStatus OnUpdate()
    {
        attackManager.Animator.SetTrigger("Death");
        // TODO: End Game/back to menu --> GameManager
        Debug.Log("Boss died!");
        return TaskStatus.COMPLETED;
    }

}
