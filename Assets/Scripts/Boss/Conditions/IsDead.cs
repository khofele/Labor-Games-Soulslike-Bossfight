using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsDead")]
public class IsDead : GOCondition
{
    [InParam("controller")]
    [SerializeField] private BossController bossController = null;

    public override bool Check()
    {
        if(bossController != null && bossController.Health <= 0 && bossController.IsDead == false)
        {
            return true;
        }

        return false;
    }
}
