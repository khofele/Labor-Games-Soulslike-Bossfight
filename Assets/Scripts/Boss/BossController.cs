using BBUnity;
using Pada1.BBCore.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float health = 1000;
    [SerializeField] private InternalBrickAsset behaviorPhaseTwo = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private Timer flyTimer = null;
    [SerializeField] private Timer stunTimer = null;
    [SerializeField] private Timer isStunnedTimer = null;
    [SerializeField] private int hitCounter = 0;
    [SerializeField] private CharController player = null;

    // TODO DEBUG
    [SerializeField] private int stunCount = 10;

    private bool isFlying = false;
    private bool isStunned = false;

    public float Health { get => health; set => health = value; }
    public Animator Animator { get => animator; }
    public bool IsFlying { get => isFlying; set => isFlying = value; }
    public Timer FlyTimer { get => flyTimer; }
    public Timer StunTimer { get => stunTimer; }
    public Timer IsStunnedTimer { get => isStunnedTimer; }
    public int HitCounter { get => hitCounter; set => hitCounter = value; }
    public int StunCount { get => stunCount; }
    public bool IsStunned { get => isStunned; set => isStunned = value; }
    public CharController Player { get => player; }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void ChangeBehavior()
    {
        if(behaviorPhaseTwo != null)
        {
            gameObject.GetComponent<BehaviorExecutor>().behavior = behaviorPhaseTwo;
            gameObject.GetComponent<BehaviorExecutor>().SetBehaviorParam("target", player);
            gameObject.GetComponent<BehaviorExecutor>().SetBehaviorParam("flyTimer", flyTimer);
        }
    }
}
