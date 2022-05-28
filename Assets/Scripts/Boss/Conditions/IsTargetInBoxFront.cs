using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTargetInBoxFront")]
public class IsTargetInBoxFront : GOCondition
{
    [InParam("collisionCheckBoxFront")]
    [SerializeField] private CollisionCheck collisionCheck = null;

    public override bool Check()
    {
        if(collisionCheck.Collision == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
