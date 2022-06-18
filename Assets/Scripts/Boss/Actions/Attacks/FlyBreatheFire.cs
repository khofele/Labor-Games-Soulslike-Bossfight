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
        bossController.GetComponent<Animator>().applyRootMotion = true;

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
        Vector3 destination = new Vector3(targetTransform.position.x, 12, targetTransform.position.z);

        navAgent.SetDestination(destination);


#if UNITY_5_6_OR_NEWER
            navAgent.isStopped = false;
#else
                navAgent.Resume();
#endif


    }


    public override TaskStatus OnUpdate()
    {
        if(bossController.IsStunned == false)
        {
            // if Timer running
            if (bossController.IsFlyingTimer.TimerOver == false)
            {
                bossController.Animator.SetTrigger(currentFire);
                switch(currentFire)
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

                Debug.Log("Fly Breathe Fire Attack");

                if (target == null)
                {
                    bossController.Player.IsCollided = false;
                    return TaskStatus.FAILED;
                }
                else if(bossController.IsStunned == true)
                {
                    navAgent.SetDestination(new Vector3(0, 12, 0));
                    bossController.Player.IsCollided = false;
                    return TaskStatus.COMPLETED;
                }
                else if (navAgent.destination != targetTransform.position && navAgent.remainingDistance <= navAgent.stoppingDistance)
                {
                    Vector3 destination = new Vector3(targetTransform.position.x, 12, targetTransform.position.z);
                    navAgent.SetDestination(destination);
                    return TaskStatus.RUNNING;
                }
            }

            //if Timer over
            if (bossController.IsFlyingTimer.TimerOver == true)
            {
                if (bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Fly Breathe Fire") ||
                    bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Fly Breathe Poison Fire") ||
                    bossController.Animator.GetCurrentAnimatorStateInfo(0).IsName("Fly Breathe Magic Fire"))
                {
                    navAgent.SetDestination(new Vector3(0, 12, 0));
                    bossController.Player.IsCollided = false;
                    return TaskStatus.COMPLETED;
                }

            }
            else
            {
                return TaskStatus.RUNNING;
            }
            bossController.Player.IsCollided = false;
            return TaskStatus.FAILED;
        }
        bossController.Player.IsCollided = false;
        return TaskStatus.COMPLETED;
        
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
