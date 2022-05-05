using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTimerRunning")]
public class IsTimerRunning : GOCondition
{
    [InParam("timer")]
    private Timer timer = null;

    public override bool Check()
    {
        if(timer.TimerOver == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
