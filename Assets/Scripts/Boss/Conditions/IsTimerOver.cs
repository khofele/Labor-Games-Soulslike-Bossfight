using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTimerOver")]
public class IsTimerOver : GOCondition
{
    [InParam("timer")]
    private Timer timer = null;

    public override bool Check()
    {
        return timer.TimerOver;
    }
}
