using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("Perception/IsTargetInSphere")]
public class IsTargetInSphere : GOCondition
{
    [InParam("collisionCheckSphere")]
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
