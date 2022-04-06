using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Stunned")]
public class Stunned : GOAction
{
    [InParam("controller")]
    [SerializeField] private BossController bossController = null;

    public override TaskStatus OnUpdate()
    {
        // play stunned animation
        // Timer
        Debug.Log("boss stunned");
        return TaskStatus.COMPLETED;
    }
}
