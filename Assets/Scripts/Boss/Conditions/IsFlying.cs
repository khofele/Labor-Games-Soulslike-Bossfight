using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsFlying")]
public class IsFlying : GOCondition
{
    private BossController bossController = null;

    public override bool Check()
    {
        bossController = gameObject.GetComponent<BossController>();
        return bossController.IsFlying;
    }
}
