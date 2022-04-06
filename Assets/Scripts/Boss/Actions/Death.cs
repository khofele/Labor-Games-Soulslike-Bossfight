using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("Death")]
public class Death : GOAction
{
    [InParam("GameManager")]
    [SerializeField] private GameManager gameManager = null;
    public override TaskStatus OnUpdate()
    {
        // Play Death Animation
        // End Game/back to menu --> GameManager
        Debug.Log("Boss died!");
        return TaskStatus.COMPLETED;
    }

}
