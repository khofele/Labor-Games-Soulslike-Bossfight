using BBUnity.Conditions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Condition("IsTargetInBoxRight")]
public class IsTargetInBoxRight : GOCondition
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

    [InParam("layermask")]
    [SerializeField] private LayerMask layerMask;

    public override bool Check()
    {
        Collider[] objectsInRange = Physics.OverlapBox(new Vector3(gameObject.transform.position.x + 5, gameObject.transform.position.y + 5, gameObject.transform.position.z - 2), new Vector3(gameObject.transform.localScale.x + 6, gameObject.transform.localScale.y, gameObject.transform.localScale.z + 45));

        for (int i = 0; i < objectsInRange.Length; i++)
        {
            if (objectsInRange[i].gameObject == target)
            {
                return true;
            }
        }

        return false;
    }
}
