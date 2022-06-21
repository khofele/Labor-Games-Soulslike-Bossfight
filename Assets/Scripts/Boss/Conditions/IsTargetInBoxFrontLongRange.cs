using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTargetInBoxFrontLongRange")]
public class IsTargetInBoxFrontLongRange : GOCondition
{
    [InParam("collisionCheckBoxFrontLongRange")]
    [SerializeField] private CollisionCheck collisionCheck = null;

    public override bool Check()
    {
        if (collisionCheck.Collision == true && collisionCheck.GetComponentInParent<BossController>().IsFlying == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
