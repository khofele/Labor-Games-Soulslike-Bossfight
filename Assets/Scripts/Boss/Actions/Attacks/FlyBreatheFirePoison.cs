using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Action("FlyBreatheFireAttackPoison")]
public class FlyBreatheFirePoison : GOAction
{
    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    [InParam("target")]
    [Help("Target game object towards this game object will be moved")]
    public GameObject target;

    private UnityEngine.AI.NavMeshAgent navAgent;

    private Transform targetTransform;

    private BossController bossController = null;

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();

        if (target == null)
        {
            Debug.LogError("The movement target of this game object is null", gameObject);
            return;
        }
        targetTransform = target.transform;

        navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (navAgent == null)
        {
            Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
            navAgent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
        }
        navAgent.SetDestination(targetTransform.position);

#if UNITY_5_6_OR_NEWER
        navAgent.isStopped = false;
#else
                navAgent.Resume();
#endif
    }


    public override TaskStatus OnUpdate()
    {

        // if Timer running
        if (bossController.FlyTimer.TimerOver == false)
        {
            bossController.Animator.SetTrigger("BreathePoisonFire");
            attackManager.CurrentAttack = attackManager.AttackFlyBreatheFirePoison;
            Debug.Log("Fly Breathe Poison Fire Attack");

            if (target == null)
            {
                return TaskStatus.FAILED;
            }
            else if (navAgent.destination != targetTransform.position && navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                navAgent.SetDestination(targetTransform.position);
                return TaskStatus.RUNNING;
            }
        }

        //if Timer over
        if (bossController.FlyTimer.TimerOver == true)
        {
            return TaskStatus.COMPLETED;
        }

        return TaskStatus.FAILED;
    }

    public override void OnAbort()
    {

#if UNITY_5_6_OR_NEWER
        if (navAgent != null)
            navAgent.isStopped = true;
#else
            if (navAgent!=null)
                navAgent.Stop();
#endif

    }
}
