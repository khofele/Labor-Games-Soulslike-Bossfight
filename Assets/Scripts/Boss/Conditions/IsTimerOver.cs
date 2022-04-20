using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTimerOver")]
public class IsTimerOver : GOCondition
{
    public override bool Check()
    {
        // TODO: bossController.Timer > 0
        return false;
    }
}
