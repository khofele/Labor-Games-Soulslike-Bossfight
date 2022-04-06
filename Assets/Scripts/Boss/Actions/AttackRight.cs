using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("AttackRight")]
public class AttackRight : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    public override TaskStatus OnUpdate()
    {
        // play attack animation
        // player take damage check
        Debug.Log("Attack Right");
        return TaskStatus.COMPLETED;
    }
}
