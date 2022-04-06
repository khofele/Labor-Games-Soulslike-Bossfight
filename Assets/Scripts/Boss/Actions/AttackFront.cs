using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("AttackFront")]
public class AttackFront : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    public override TaskStatus OnUpdate()
    {
        // play attack animation
        // player take damage check
        Debug.Log("Attack Front");
        return TaskStatus.COMPLETED;
    }
}
