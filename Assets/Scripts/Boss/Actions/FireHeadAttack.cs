using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("FireHeadAttack")]
public class FireHeadAttack : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    public override TaskStatus OnUpdate()
    {
        // play attack animation
        // player take damage check
        Debug.Log("Attack Fire Head");
        return TaskStatus.COMPLETED;
    }
}
