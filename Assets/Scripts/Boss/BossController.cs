using BBUnity;
using Pada1.BBCore.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float health = 5000;
    [SerializeField] private InternalBrickAsset behaviorPhaseTwo = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private Timer flyTimer = null;
    [SerializeField] private Timer isStunnedTimer = null;
    [SerializeField] private Timer isFlyingTimer = null;
    [SerializeField] private int hitCounter = 0;
    [SerializeField] private CharController player = null;
    [SerializeField] private List<CapsuleCollider> capsuleCollider = new List<CapsuleCollider>();
    [SerializeField] private List<BoxCollider> boxCollider = new List<BoxCollider>();

    // TODO DEBUG
    [SerializeField] private int stunCount = 15;

    private bool isFlying = false;
    private bool isStunned = false;

    public float Health { get => health; set => health = value; }
    public Animator Animator { get => animator; }
    public bool IsFlying { get => isFlying; set => isFlying = value; }
    public Timer FlyTimer { get => flyTimer; }
    public Timer IsStunnedTimer { get => isStunnedTimer; }
    public Timer IsFlyingTimer { get => isFlyingTimer; }
    public int HitCounter { get => hitCounter; set => hitCounter = value; }
    public int StunCount { get => stunCount; }
    public bool IsStunned { get => isStunned; set => isStunned = value; }
    public CharController Player { get => player; }

    private void Awake()
    {
        DisableAttackCollider();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void ChangeBehavior()
    {
        if(behaviorPhaseTwo != null)
        {
            gameObject.GetComponent<BehaviorExecutor>().behavior = behaviorPhaseTwo;

            gameObject.GetComponent<BehaviorExecutor>().SetBehaviorParam("isFlyingTimer", isFlyingTimer);
            gameObject.GetComponent<BehaviorExecutor>().SetBehaviorParam("flyTimer", flyTimer);
            flyTimer.StartTimer();
        }
    }

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
