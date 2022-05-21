using BBUnity;
using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("ChangeBehaviorPhaseOne")]
public class ChangeBehaviorPhaseOne : GOAction
{
    [InParam("phaseOne")]
    [SerializeField] private InternalBrickAsset behaviorPhaseOne = null;

    [InParam("area")]
    [SerializeField] private GameObject area = null;

    [InParam("player")]
    [SerializeField] private CharController player = null;

    [InParam("layerMask")]
    [SerializeField] private LayerMask layerMask;

    [InParam("bossController")]
    [SerializeField] private BossController bossController = null;

    [InParam("gameManager")]
    [SerializeField] private GameManager gameManager = null;

    [InParam("attackManager")]
    [SerializeField] private AttackManager attackManager = null;

    [InParam("IsStunnedTimer")]
    [SerializeField] private Timer isStunnedTimer = null;

    private BehaviorExecutor behaviorExecutor = null;

    public override void OnStart()
    {
        behaviorExecutor = gameObject.GetComponent<BehaviorExecutor>();
    }

    public override TaskStatus OnUpdate()
    {
        behaviorExecutor.behavior = behaviorPhaseOne;
        behaviorExecutor.SetBehaviorParam("area", area);
        behaviorExecutor.SetBehaviorParam("player", player);
        behaviorExecutor.SetBehaviorParam("layermask", layerMask);
        behaviorExecutor.SetBehaviorParam("bossController", bossController);
        behaviorExecutor.SetBehaviorParam("gameManager", gameManager);
        behaviorExecutor.SetBehaviorParam("attackManager", attackManager);
        behaviorExecutor.SetBehaviorParam("IsStunnedTimer", isStunnedTimer);
        gameManager.GameRunning = true;

        return TaskStatus.COMPLETED;
    }
}
