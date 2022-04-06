using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTargetInBoxFrontLongRange")]
public class IsTargetInBoxFrontLongRange : GOCondition
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    [InParam("layermask")]
    [SerializeField] private LayerMask layerMask;

    [InParam("box range")]
    [SerializeField] private int boxRange = 35;

    public override bool Check()
    {
        Collider[] objectsInRange = Physics.OverlapBox(gameObject.transform.position, new Vector3(gameObject.transform.localScale.x + 10, gameObject.transform.localScale.y + 5, gameObject.transform.localScale.z + boxRange));

        for (int i = 0; i < objectsInRange.Length; i++)
        {
            if(objectsInRange[i].gameObject == target)
            {
                return true;
            }
        }
        return false;
    }
}
