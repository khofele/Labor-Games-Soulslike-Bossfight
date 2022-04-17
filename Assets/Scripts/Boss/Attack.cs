using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    private float damageMin = 0;
    private float damageMax = 0;
    private float damage = 0;

    private Animation animation = null;

    public float Damage
    {
        get => damage = Random.Range(damageMin, damageMax);
    }

    public Attack(float damageMin, float damageMax)
    {
        this.damageMin = damageMin;
        this.damageMax = damageMax;
    }    
}
