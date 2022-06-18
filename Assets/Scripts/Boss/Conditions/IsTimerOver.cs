using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTimerOver")]
public class IsTimerOver : GOCondition
{
    [InParam("bossController")]
    private BossController bossController = null;

    public override bool Check()
    {
        return bossController.FlyTimer.TimerOver;
    }
}
