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

    public override bool Check()
    {
        Collider[] objectsInRange = Physics.OverlapBox(new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + 2.5f), gameObject.transform.position.z + 16.5f), new Vector3(gameObject.transform.localScale.x + 3, gameObject.transform.localScale.y + 5, gameObject.transform.localScale.z + 15), gameObject.transform.rotation);

        for (int i = 0; i < objectsInRange.Length; i++)
        {
            if(objectsInRange[i].gameObject.layer == layerMask)
            {
                return true;
            }
        }
        return false;
    }
}
