using BBUnity.Actions;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Action("FlyBreatheFireAttack")]
public class FlyBreatheFire : GOAction
{
    [InParam("attack manager")]
    [SerializeField] private AttackManager attackManager = null;

    [InParam("target")]
    [Help("Target game object towards this game object will be moved")]
    public GameObject target;

    private UnityEngine.AI.NavMeshAgent navAgent;

    private Transform targetTransform;

    private BossController bossController = null;

    private string basicFire = "BreatheBasicFire";
    private string poisonFire = "BreathePoisonFire";
    private string magicFire = "BreatheMagicFire";
    private string currentFire = "";

    public override void OnStart()
    {
        bossController = gameObject.GetComponent<BossController>();
        target = bossController.Player.gameObject;
        bossController.GetComponent<Animator>().applyRootMotion = true;

        // take off
        bossController.Animator.ResetTrigger("Idle");
        bossController.Animator.SetTrigger("TakeOff");

        // fly idle
        bossController.FlyTimer.TimerEnd();
        bossController.IsFlyingTimer.StartTimer(45);
        bossController.Animator.SetTrigger("FlyIdle");

        // choose fire
        int random = Random.Range(1, 100);
        if (random >= 1 && random <= 33)
        {
            currentFire = basicFire;
        }
        else if(random >= 33 && random <= 66)
        {
            currentFire = poisonFire;
        }
        else
        {
            currentFire = magicFire;
        }

        if (target == null)
        {
            Debug.LogError("The movement target of this game object is null", gameObject);
            return;
        }
        targetTransform = target.transform;
        navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAgent.isStopped = false;

        if (navAgent == null)
        {
            Debug.LogWarning("The " + gameObject.name + " game object does not have a Nav Mesh Agent component to navigate. One with default values has been added", gameObject);
            navAgent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
        }

        // set fire animation and destination
        navAgent.SetDestination(targetTransform.position);
        bossController.Animator.SetTrigger(currentFire);


#if UNITY_5_6_OR_NEWER
        navAgent.isStopped = false;
#else
                navAgent.Resume();
#endif


    }


    public override TaskStatus OnUpdate()
    {
        if (bossController.IsStunned == false)
        {

            bossController.Animator.ResetTrigger("FlyIdle");

            // current attack
            switch (currentFire)
            {
                case "BreatheBasicFire":
                    attackManager.CurrentAttack = attackManager.AttackFlyBreatheFire;
                    break;

                case "BreathePoisonFire":
                    attackManager.CurrentAttack = attackManager.AttackFlyBreatheFirePoison;
                    break;

                case "BreatheMagicFire":
                    attackManager.CurrentAttack = attackManager.AttackFlyBreatheFireMagic;
                    break;
            }

            // fly timer over/invoke landing
            if (bossController.IsFlyingTimer.TimerOver == true)
            {
                navAgent.isStopped = true;
                bossController.Animator.ResetTrigger(GetCurrentAttackTrigger());
                bossController.Animator.ResetTrigger("Idle");
                bossController.Animator.SetBool("isLanding", true);
                bossController.Animator.SetTrigger("Land");
                bossController.FlyTimer.StartTimer();
                bossController.IsFlying = false;
                bossController.Player.IsCollided = false;
                bossController.Animator.SetBool("isFlying", false);
                bossController.Animator.SetTrigger("Idle");
                return TaskStatus.COMPLETED;
            }
            // set new destination
            else if (navAgent.destination != targetTransform.position)
            {
                navAgent.SetDestination(targetTransform.position);
                bossController.Animator.SetTrigger(currentFire);
            }
            return TaskStatus.RUNNING;
        }
        else
        {
            return TaskStatus.ABORTED;
        }
    }

    public override void OnAbort()
    {

#if UNITY_5_6_OR_NEWER
        if (navAgent != null)
            navAgent.isStopped = true;
        bossController.FlyTimer.StartTimer();
        bossController.IsFlyingTimer.TimerEnd();
#else
            if (navAgent!=null)
                navAgent.Stop();
#endif

    }

    private string GetCurrentAttackTrigger()
    {
        if(currentFire == basicFire)
        {
            return "BreatheBasicFire";
        }
        else if(currentFire == poisonFire)
        {
            return "BreathePoisonFire";
        }
        else if(currentFire == magicFire)
        {
            return "BreatheMagicFire";
        }

        return null;
    }
}
