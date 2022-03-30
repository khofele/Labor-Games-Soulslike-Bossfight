using BBUnity.Actions;
using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Attack")]
public class Attack : GOAction
{
    [InParam("target")]
    [SerializeField] private GameObject target = null;

}
