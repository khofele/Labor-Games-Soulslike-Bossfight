using BBUnity.Actions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("RangeAttack")]
public class RangeAttack : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

}
