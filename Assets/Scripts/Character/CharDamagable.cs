using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDamagable : MonoBehaviour
{
    [SerializeField] private GameObject attackManager; //the attack manager of the dragon
    [SerializeField] private float crit = 0; //crit is set for every collider on itself
    private CharController charController = null;

    private float dotPercentage = 0.4f; //percentage of damage value that gives damage over time
    private float dotDelay = 30f; //delay for damage dealing over time
    private float dotValuePercentage = 0.1f; //percentage of dot that is dealt at once

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponentInParent<CharController>();
    }

    //called when hit
    private void OnCollisionEnter(Collision collision)
    {
        if (!charController.GetComponentInParent<Animator>().GetBool("Roll"))
        {
            //deal damage according to attack
            //float damage = attackManager.CurrentAttack.Damage;
            float damage = 200f; //test value
            float dot = damage * dotPercentage;

            //call method to calculate damage
            charController.TakeDamage(damage + crit);

            //if special attack with fire, poison or magic - call method to deal damage over time
            //if(attackManager.CurrentAttack.ToString().Contains == "FlyBreatheFire")
            //{
            //float dot = attackManager.CurrentAttack.Damage * dotPercentage;
            float valueEveryTime = dot * dotValuePercentage;    //damage value that is dealt every time of damage over time
            //charController.DamageOverTime(dot, dotDelay, valueEveryTime);
            //}

            //test
            charController.StartCoroutine(charController.DamageOverTime(dot, dotDelay, valueEveryTime));
        }
    }
}
