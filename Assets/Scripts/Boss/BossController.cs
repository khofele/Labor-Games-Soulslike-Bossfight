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

    private bool isFlying = false;

    public float Health { get => health; set => health = value; }
    public Animator Animator { get => animator; }
    public bool IsFlying { get => isFlying; set => isFlying = value; }
    public Timer FlyTimer { get => flyTimer; }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void ChangeBehavior()
    {
        if(behaviorPhaseTwo != null)
        {
            gameObject.GetComponent<BehaviorExecutor>().behavior = behaviorPhaseTwo;
        }
    }
}
