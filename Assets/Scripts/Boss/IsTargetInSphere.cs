using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("Perception/IsTargetInSphere")]
public class IsTargetInSphere : GOCondition
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    [InParam("Layermask")]
    [SerializeField] private LayerMask layerMask;

    [InParam("Range")]
    [SerializeField] private int range = 10;

    public override bool Check()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(gameObject.transform.position, range, layerMask);
        
        for(int i = 0; i < objectsInRange.Length; i++)
        {
            if(objectsInRange[i].gameObject == target)
            {
                return true;
            }
        }
        return false;
    }
}
