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
    
    [InParam("target")]
    [SerializeField] private GameObject target = null;

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

    [InParam("collisionCheckBoxFront")]
    [SerializeField] private CollisionCheck collisionCheckFront = null;

    [InParam("collisionCheckBoxFrontLongRange")]
    [SerializeField] private CollisionCheck collisionCheckFrontLongRange = null;

    [InParam("collisionCheckBoxLeft")]
    [SerializeField] private CollisionCheck collisionCheckLeft = null;

    [InParam("collisionCheckBoxRight")]
    [SerializeField] private CollisionCheck collisionCheckRight = null;

    [InParam("collisionCheckSphere")]
    [SerializeField] private CollisionCheck collisionCheckSphere = null;

    private BehaviorExecutor behaviorExecutor = null;

    public override void OnStart()
    {
        behaviorExecutor = gameObject.GetComponent<BehaviorExecutor>();
        target = player.gameObject;
    }

    public override TaskStatus OnUpdate()
    {
        behaviorExecutor.behavior = behaviorPhaseOne;
        behaviorExecutor.SetBehaviorParam("area", area);
        behaviorExecutor.SetBehaviorParam("player", player);
        behaviorExecutor.SetBehaviorParam("target", target);
        behaviorExecutor.SetBehaviorParam("layermask", layerMask);
        behaviorExecutor.SetBehaviorParam("bossController", bossController);
        behaviorExecutor.SetBehaviorParam("gameManager", gameManager);
        behaviorExecutor.SetBehaviorParam("attackManager", attackManager);
        behaviorExecutor.SetBehaviorParam("IsStunnedTimer", isStunnedTimer);
        behaviorExecutor.SetBehaviorParam("collisionCheckBoxFront", collisionCheckFront);
        behaviorExecutor.SetBehaviorParam("collisionCheckBoxFrontLongRange", collisionCheckFrontLongRange);        
        behaviorExecutor.SetBehaviorParam("collisionCheckBoxLeft", collisionCheckLeft);        
        behaviorExecutor.SetBehaviorParam("collisionCheckBoxRight", collisionCheckRight);
        behaviorExecutor.SetBehaviorParam("collisionCheckSphere", collisionCheckSphere);

        gameManager.GameRunning = true;

        return TaskStatus.COMPLETED;
    }
}
