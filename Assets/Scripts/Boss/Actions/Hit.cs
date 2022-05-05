using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Hit")]
public class Hit : GOAction
{
    [InParam("controller")]
    [SerializeField] private BossController bossController = null;

    public override TaskStatus OnUpdate()
    {
        // play hit animation
        // stunned counter
        Debug.Log("boss hit");
        return TaskStatus.COMPLETED;
    }
}
