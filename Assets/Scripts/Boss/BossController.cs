using BBUnity;
using Pada1.BBCore.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private int health = 1000;
    [SerializeField] private InternalBrickAsset behaviorPhaseTwo = null;

    public int Health
    {
        get => health;
        set
        {
            health = value;
        }
    }

    public void TakeDamage(Collider collider, int damage) // TODO: vom Spieler aufrufen?
        // TODO: anpassen --> je nach collider mehr oder weniger Health abziehen
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
