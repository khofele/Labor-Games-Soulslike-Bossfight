using BBUnity;
using Pada1.BBCore.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private InternalBrickAsset behaviorPhaseTwo = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private Timer flyTimer = null;
    [SerializeField] private Timer isStunnedTimer = null;
    [SerializeField] private Timer stunTimer = null;
    [SerializeField] private Timer isFlyingTimer = null;
    [SerializeField] private int hitCounter = 0;
    [SerializeField] private CharController player = null;
    [SerializeField] private List<CapsuleCollider> capsuleCollider = new List<CapsuleCollider>();
    [SerializeField] private List<BoxCollider> boxCollider = new List<BoxCollider>();
    [SerializeField] private GameObject hitbox = null;

    private int stunCount = 8;
    private float health = 28000;
    private bool isFlying = false;
    private bool isStunned = false;
    private bool isDead = false;

    public GameObject Hitbox { get => hitbox; }

    public float Health { get => health; set => health = value; }
    public Animator Animator { get => animator; }
    public bool IsFlying { get => isFlying; set => isFlying = value; }
    public Timer FlyTimer { get => flyTimer; }
    public Timer StunTimer { get => stunTimer; }
    public Timer IsStunnedTimer { get => isStunnedTimer; }
    public Timer IsFlyingTimer { get => isFlyingTimer; }
    public int HitCounter { get => hitCounter; set => hitCounter = value; }
    public int StunCount { get => stunCount; }
    public bool IsStunned { get => isStunned; set => isStunned = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public CharController Player { get => player; }

    private void Awake()
    {
        DisableAttackCollider();
    }

    private void Update()
    {
        if(flyTimer.TimerOver == true && gameManager.PhaseTwo == true)
        {
            isFlying = true;
            animator.SetBool("isFlying", true);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void ChangeBehavior()
    {
        if(behaviorPhaseTwo != null)
        {
            gameObject.GetComponent<BehaviorExecutor>().restartWhenFinished = false;
            gameObject.GetComponent<BehaviorExecutor>().paused = true;
            gameObject.GetComponent<BehaviorExecutor>().behavior = behaviorPhaseTwo;
            gameObject.GetComponent<BehaviorExecutor>().restartWhenFinished = true;
            gameObject.GetComponent<BehaviorExecutor>().paused = false;

            gameObject.GetComponent<BehaviorExecutor>().SetBehaviorParam("isFlyingTimer", isFlyingTimer);
            gameObject.GetComponent<BehaviorExecutor>().SetBehaviorParam("flyTimer", flyTimer);
            flyTimer.StartTimer(10);
        }
    }

    //--------------------------COLLIDER METHODS FOR ATTACKS-----------------------

    public void EnableAttackCollider()
    {
        foreach(CapsuleCollider capsuleCollider in capsuleCollider)
        {
            capsuleCollider.enabled = true;
        }

        foreach(BoxCollider boxCollider in boxCollider)
        {
            boxCollider.enabled = true;
        }
    }    
    
    public void DisableAttackCollider()
    {
        foreach(CapsuleCollider capsuleCollider in capsuleCollider)
        {
            capsuleCollider.enabled = false;
        }

        foreach(BoxCollider boxCollider in boxCollider)
        {
            boxCollider.enabled = false;
        }
    }
}
