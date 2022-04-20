using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTimerRunning")]
public class IsTimerRunning : GOCondition
{
    public override bool Check()
    {
        // TODO: bossController.Timer > 0
        return false;
    }
}
