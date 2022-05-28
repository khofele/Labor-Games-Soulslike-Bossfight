using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTargetInBoxLeft")]
public class IsTargetInBoxLeft : GOCondition
{
    [InParam("collisionCheckBoxLeft")]
    [SerializeField] private CollisionCheck collisionCheck = null;

    public override bool Check()
    {
        if (collisionCheck.Collision == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
